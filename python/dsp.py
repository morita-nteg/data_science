import numpy as np
import pandas as pd


coeff = 1.0

def maxfreq(dt):
    return 1/dt

def resolution(t):
    return 1 / t

# CSVの n 列目を時系列データとして取得
def load_timewave(filename, col):
    df = pd.read_csv(filename, header=None)
    x_all = df[col].to_numpy()
    return x_all * coeff

# CSVの n 列目を時系列データとして取得
# 区間 [offset, offset+n_smp] の値を取得
def load_timewave(filename, col, offset, n_smp):
    df = pd.read_csv(filename, header=None)
    x_all = df[col].to_numpy()
    x = x_all[offset:offset+n_smp] * coeff
    return x

def padding(x, l):
    return np.pad(x, [0,l], 'constant')

# 片振幅FFT
def fft(x):
    x_len = len(x)
    y = np.fft.fft(x)
    # 片振幅
    return abs(y / (x_len/2))

def bpf_single(interval, res, y, f):
    (f_low, f_up) = interval
    n_low = (int)(f_low / res)
    n_up = (int)(f_up / res)
    if n_low <= f and f < n_up:
        return y[f]
    else:
        return 0.0

# band pass filter
# 周波数領域で f ∈ I1 ∪ I2 ∪ ... ∪ In の場合を通す
def bpf(intervals, res , y, f):
    for interval in intervals:
        (f_low, f_up) = interval
        n_low = (int)(f_low / res)
        n_up = (int)(f_up / res)
        if n_low <= f and f < n_up:
            return y[f]

    # 遮断時は 0 を返す
    return 0.0

