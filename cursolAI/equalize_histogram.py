

#
# Python KL-Divergence
#
import sys
import cv2
import numpy as np
import matplotlib.pyplot as plt


if __name__ == '__main__':
    if (len(sys.argv) >= 1):
        input = sys.argv[1]

        cmat = cv2.imread(input)
        mat = cv2.cvtColor(cmat, cv2.COLOR_BGR2GRAY)

        # Otsu 2値化
        _, otsu_th = cv2.threshold(mat, 0, 255, cv2.THRESH_OTSU)
        cv2.imwrite('otsu_th.png', otsu_th)

        
        # ヒストグラム平滑化画像の生成
        equalized_img = cv2.equalizeHist(mat)
        cv2.imwrite('equalized_img.png', equalized_img)
