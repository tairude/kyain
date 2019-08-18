import argparse
import logging
import sys
import time
import math

from tf_pose import common
import cv2
import matplotlib.pyplot as plt
import numpy as np
from tf_pose.estimator import TfPoseEstimator
from tf_pose.networks import get_graph_path, model_wh
import flask

logger = logging.getLogger('TfPoseEstimatorRun')
logger.handlers.clear()
logger.setLevel(logging.DEBUG)
ch = logging.StreamHandler()
ch.setLevel(logging.DEBUG)
formatter = logging.Formatter('[%(asctime)s] [%(name)s] [%(levelname)s] %(message)s')
ch.setFormatter(formatter)
logger.addHandler(ch)
app = flask.Flask(__name__)
config = {
    'image':'../KyainWeb/images/kyain.jpg',
    'model':'mobilenet_thin',
    'resize':'432x368',
    'resize_out_ratio': 4.0,
}
vec_i = [(0,1),(4,3),(3,2),(2,5),(5,6),(6,7),(2,8),(5,11),(8,9),(9,10),(11,12),(12,13)]

w, h = model_wh(config['resize'])
e = TfPoseEstimator(get_graph_path(config['model']), target_size=(w, h)) 

def cos_sim(v1, v2):
    return np.dot(v1, v2) / (np.linalg.norm(v1) * np.linalg.norm(v2))

@app.route("/predict", methods=["GET"])
def predict():
    response = {
        "success": False,
        "Content-Type": "application/json"
    }

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
                x = 0
                y = 0
            else:
                body_part = human.body_parts[i]
                x = body_part.x
                y = body_part.y

            center = (int(x * image_w + 0.5), int(y * image_h + 0.5))
            human_pts_list[hid,i,0] = center[0]
            human_pts_list[hid,i,1] = center[1]
           
    #print(human_pts_list)

    vec_list = np.zeros((len(humans),12,2))
    for hid in range(len(humans)):
        for (v,i)in zip(vec_i,range(12)):
            vec_list[hid,i,0] = human_pts_list[hid,v[0],0] - human_pts_list[hid,v[1],0]
            vec_list[hid,i,1] = human_pts_list[hid,v[0],1] - human_pts_list[hid,v[1],1]


    # print(vec_list)

    cos_list = np.zeros(12)
    for i in range(12):
        cos_list[i] = cos_sim(vec_list[0,i],vec_list[1,i])
        
    cos_list_fix = [x for x in cos_list if (math.isnan(x) == False)]
    # print(cos_list)
    #print('score:',np.mean(cos_list))

    logger.info('inference image: %s in %.4f seconds.' % (config['image'], elapsed))
    result_image = TfPoseEstimator.draw_humans(image, humans, imgcopy=False)

    try:
        plt.imsave('../KyainWeb/images/kyain_result.jpg', cv2.cvtColor(result_image, cv2.COLOR_BGR2RGB))
    except:
        pass

    response["prediction"] = np.mean(cos_list_fix)
    response["success"] = True
    return flask.jsonify(response)

if __name__ == '__main__':
    print(" * Flask starting server...")
    app.run()