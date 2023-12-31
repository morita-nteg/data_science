

#
# Python KL-Divergence
#
import sys
import cv2
import numpy as np
import matplotlib.pyplot as plt

# Ctrl-K : 画像ファイルからグレースケール mat を取得する処理
#   image = cv2.imread(filename)
#   gray_image = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

#　Ctrl-K : 画像のヒストグラムを算出する関数
#    hist = cv2.calcHist([image], [0], None, [256], [0, 256])
#    plt.plot(hist)
#    plt.show()


if __name__ == '__main__':

    argn = len(sys.argv)
    inputs = sys.argv[1:argn-1]
    for n in range(1,argn):
        cmat = cv2.imread(sys.argv[n])
        mat = cv2.cvtColor(cmat, cv2.COLOR_BGR2GRAY)
        hist = cv2.calcHist([mat], [0], None, [256], [0, 256])
        plt.plot(hist)
    
    plt.show()