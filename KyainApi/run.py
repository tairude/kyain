import argparse
import logging
import sys
import time

from tf_pose import common
import cv2
import numpy as np
from tf_pose.estimator import TfPoseEstimator
from tf_pose.networks import get_graph_path, model_wh

logger = logging.getLogger('TfPoseEstimatorRun')
logger.handlers.clear()
logger.setLevel(logging.DEBUG)
ch = logging.StreamHandler()
ch.setLevel(logging.DEBUG)
formatter = logging.Formatter('[%(asctime)s] [%(name)s] [%(levelname)s] %(message)s')
ch.setFormatter(formatter)
logger.addHandler(ch)


if __name__ == '__main__':
    config = {
        'image':'./images/kyain.jpg',
        'model':'mobilenet_thin',
        'resize':'432x368',
        'resize_out_ratio': 4.0,
    }

    w, h = model_wh(config['resize'])
    e = TfPoseEstimator(get_graph_path(config['model']), target_size=(w, h)) 

    # estimate human poses from a single image !
    image = common.read_imgfile(config['image'], None, None)

    if image is None:
        logger.error('Image can not be read, path=%s' % config['image'])
        sys.exit(-1)

    t = time.time()
    humans = e.inference(image, resize_to_default=(w > 0 and h > 0), upsample_size=config['resize_out_ratio'])
    elapsed = time.time() - t
    human_pts_list = np.zeros((len(humans),18,2))
    image_h, image_w = image.shape[:2]
    for hid,human in enumerate(humans):
        # draw point
        for i in range(common.CocoPart.Background.value):
            if i not in human.body_parts.keys():
                center = -1,-1

            body_part = human.body_parts[i]
            center = (int(body_part.x * image_w + 0.5), int(body_part.y * image_h + 0.5))
            human_pts_list[hid,i,0] = center[0]
            human_pts_list[hid,i,1] = center[1]
           
    print(human_pts_list)

    logger.info('inference image: %s in %.4f seconds.' % (config['image'], elapsed))

    image = TfPoseEstimator.draw_humans(image, humans, imgcopy=False)

    try:
        import matplotlib.pyplot as plt

        fig = plt.figure()
        a = fig.add_subplot(1, 1, 1)
        a.set_title('Result')
        plt.imshow(cv2.cvtColor(image, cv2.COLOR_BGR2RGB))
        for human_pt in human_pts_list:
            for h in human_pt:
                plt.plot(h[0],h[1],marker='.')
        plt.show()
    except Exception as e:
        logger.warning('matplitlib error, %s' % e)
        cv2.imshow('result', image)
        cv2.waitKey()
