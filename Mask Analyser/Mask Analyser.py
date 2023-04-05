import cv2
import numpy as np
import tkinter as tk
import tkinter.filedialog as fd
import tkinter.messagebox as mb



from tkinter import *

global file_path_global_mask
root_for_global_mask = tk.Tk()
root_for_global_mask.withdraw()
#try:
file_path = fd.askopenfilename(title='Choose the Global Mask', filetypes = ((".PNG file", "*.PNG"),))
if file_path != '' and file_path != None:
    file_path_global_mask = cv2.imread(file_path)
    print("\nChosen Global mask: " + file_path)
    file_path_global_mask = cv2.imread(file_path)
        #ret2,thresh_binared = cv2.threshold(frame,file_path_global_mask.get(),255,cv2.THRESH_BINARY)
    cv2.imshow("preview", file_path_global_mask)
else:
    tk.messagebox.showwarning(title='Mask_Warning!', message='You should choose the mask!')

full_sum_of_white_pixels_global = np.sum(file_path_global_mask)//255//3
print (full_sum_of_white_pixels_global)
print ((200*200/full_sum_of_white_pixels_global))