import numpy as np
import cv2
import tkinter as tk
import tkinter.filedialog as fd
import tkinter.messagebox as mb
from tkinter import *
from skimage import data, filters


def Btn_for_load_Сlicked():
    global filez, frame, cap, ret, ret2, file_no, frame_no
    #global
    file_no = 0
    frame_no = 0
    root = tk.Tk()
    root.withdraw()
    filez = fd.askopenfilenames(parent=root, title='Choose a file', filetypes = (("Файл видео", "*.avi"),))
    print (filez)
    if len(filez) > 0:
        cap = cv2.VideoCapture(filez[file_no])
        ret, frame = cap.read()
        #if ret == True:
            #ret2,thresh_binared = cv2.threshold(frame,var_for_spin.get(),255,cv2.THRESH_BINARY)
        cv2.imshow("preview " + str(filez[0]), frame)
            #cv2.namedWindow('controls')
            #cv2.createTrackbar('video_trackbar','controls',0,880, Trackbar_changed_value())

def Btn_for_Global_mask_Сlicked():
    global file_path_global_mask
    root_for_global_mask = tk.Tk()
    root_for_global_mask.withdraw()
    #try:
    file_path = fd.askopenfilename(title='Choose the Global Mask', filetypes = ((".PNG file", "*.PNG"),))
    if file_path != '' and file_path != None:
        file_path_global_mask = (cv2.cvtColor(cv2.imread(file_path), cv2.COLOR_BGR2GRAY))
        print("\nChosen Global mask: " + file_path)
    else:
        tk.messagebox.showwarning(title='Mask_Warning!', message='You should choose the mask!')

def Btn_for_mask_1_Сlicked():
    global file_path_mask_1
    root_for_mask_1 = tk.Tk()
    root_for_mask_1.withdraw()

    file_path = fd.askopenfilename(title='Choose the Mask1', filetypes = ((".PNG file", "*.PNG"),))
    if file_path != '' and file_path != None:
        file_path_mask_1 = (cv2.cvtColor(cv2.imread(file_path), cv2.COLOR_BGR2GRAY))
        print("\nChosen mask1: " + file_path)
    else:
        tk.messagebox.showwarning(title='Mask_Warning!', message='You should choose the mask!')

def Btn_for_mask_2_Сlicked():
    global file_path_mask_2
    root_for_mask_2 = tk.Tk()
    root_for_mask_2.withdraw()
    file_path = fd.askopenfilename(title='Choose the Mask2', filetypes = ((".PNG file", "*.PNG"),))
    if file_path != '' and file_path != None:
        file_path_mask_2 = (cv2.cvtColor(cv2.imread(file_path), cv2.COLOR_BGR2GRAY))
        print("\nChosen mask2: " + file_path)
    else:
        tk.messagebox.showwarning(title='Mask_Warning!', message='You should choose the mask!')


def on_closing():
    raise SystemExit

def Btn_for_screenshot_Clicked():
    global filez, frame
    cv2.imwrite(filez[0]+'.png', frame)
    print('screenshot saved at: '+ filez[0]+'.png')
#=====================================

#=====================================
def Btn_for_start_Clicked():
    global filez
    file_no = 0
    file_for_all_analysis = open(filez[0]+'all_analysis.txt', "a")
    #file_for_all_analysis.write(str(var_for_spin.get()) + '\n')
    while file_no < len(filez):
        # Open Video
#=========================================================== обнуление переменных для подсчёта ==================================
        sum_of_white_pixels_global =0
        full_sum_of_white_pixels_global =0
        sum_of_white_pixels_global_delta = 0
        full_sum_of_white_pixels_global_delta = 0

        sum_of_white_pixels_top = 0
        full_sum_of_white_pixels_top = 0
        sum_of_white_pixels_top_delta = 0
        full_sum_of_white_pixels_top_delta = 0

        sum_of_white_pixels_bot = 0
        full_sum_of_white_pixels_bot = 0
        sum_of_white_pixels_bot_delta = 0
        full_sum_of_white_pixels_bot_delta = 0
#=================================================================================================================================
        frame_no = 0
        cap = cv2.VideoCapture(filez[file_no])
        print(filez[file_no])
        file_for_one_file = open(filez[file_no]+'.txt', "a")

        # Randomly select 100 frames
        frameIds = cap.get(cv2.CAP_PROP_FRAME_COUNT) * np.random.uniform(low=0.05, high=0.9, size=100)
        #print(frameIds)

        # Store selected frames in an array
        frames = []
        for fid in frameIds:
            cap.set(cv2.CAP_PROP_POS_FRAMES, fid)
            ret, frame = cap.read()
            frames.append(frame)

        # Calculate the median along the time axis
        medianFrame = np.median(frames, axis=0).astype(dtype=np.uint8)

        # Display median frame
        #cv2.imshow('Median_Frame', medianFrame)

        # Reset frame number to 0
        cap.set(cv2.CAP_PROP_POS_FRAMES, 0)

        # Convert background to grayscale
        grayMedianFrame = cv2.cvtColor(medianFrame, cv2.COLOR_BGR2GRAY)

        # Loop over all frames
        ret = True
        while(ret):

            # Read frame
            ret, frame = cap.read()
            if ret == True:
                #frame_no+=1
                #print(frame_no)
                # Convert current frame to grayscale
                frame = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
                # Calculate absolute difference of current frame and
                # the median frame
                dframe = cv2.absdiff(frame, grayMedianFrame)
                # Treshold to binarize
                th, dframe = cv2.threshold(dframe, 30, 255, cv2.THRESH_BINARY)
                #print(dframe[100,100])
                # Display image
                #==========================================================================================
                #                                   Удаление точек
                #src = cv2.cvtColor(dframe, cv2.COLOR_BGR2GRAY)

                ret3, binary_map2 = cv2.threshold(dframe,127,255,0)

                # do connected components processing
                nlabels, labels, stats, centroids = cv2.connectedComponentsWithStats(binary_map2, None, None, None, 8, cv2.CV_32S)

                #get CC_STAT_AREA component as stats[label, COLUMN]
                areas = stats[1:,cv2.CC_STAT_AREA]

                result = np.zeros((labels.shape), np.uint8)

                for i in range(0, nlabels - 1):
                    if areas[i] >= 100:   #keep
                        result[labels == i + 1] = 255
                #==========================================================================================
                #cv2.imshow('frame', dframe)
                #cv2.imshow('result', result)
                #cv2.waitKey(100)
#==========================================================================================================================================================
                ###                          Обсчет ТУТ
                if (frame_no == 0):
                    thresh_binared_global = cv2.bitwise_and(result,file_path_global_mask)
                    thresh_binared_top = cv2.bitwise_and(thresh_binared_global,file_path_mask_1)
                    thresh_binared_bot = cv2.bitwise_and(thresh_binared_global,file_path_mask_2)

                    full_sum_of_white_pixels_global += np.sum(thresh_binared_global)
                    thresh_binared_previous = thresh_binared_global
                else:
                    thresh_binared_global = cv2.bitwise_and(result,file_path_global_mask)
                    thresh_binared_top = cv2.bitwise_and(thresh_binared_global,file_path_mask_1)
                    thresh_binared_bot = cv2.bitwise_and(thresh_binared_global,file_path_mask_2)

                    #cv2.imshow('With Mask', thresh_binared_global)

                    sum_of_white_pixels_global = np.sum(thresh_binared_global)
                    sum_of_white_pixels_top = np.sum(thresh_binared_top)
                    sum_of_white_pixels_bot = np.sum(thresh_binared_bot)

                    full_sum_of_white_pixels_global += sum_of_white_pixels_global
                    full_sum_of_white_pixels_top += sum_of_white_pixels_top
                    full_sum_of_white_pixels_bot += sum_of_white_pixels_bot

                    sum_of_white_pixels_global_delta = np.sum(cv2.bitwise_xor(thresh_binared_previous,thresh_binared_global))
                    sum_of_white_pixels_top_delta = np.sum(cv2.bitwise_xor(cv2.bitwise_and(thresh_binared_previous,file_path_mask_1), thresh_binared_top))
                    sum_of_white_pixels_bot_delta = np.sum(cv2.bitwise_xor(cv2.bitwise_and(thresh_binared_previous,file_path_mask_2), thresh_binared_bot))

                    #cv2.imshow('Delta', cv2.bitwise_xor(thresh_binared_previous,thresh_binared_global))

                    full_sum_of_white_pixels_global_delta += sum_of_white_pixels_global_delta
                    full_sum_of_white_pixels_top_delta += sum_of_white_pixels_top_delta
                    full_sum_of_white_pixels_bot_delta += sum_of_white_pixels_bot_delta

                    thresh_binared_previous = thresh_binared_global

                    #file_for_one_file.write(str(frame_no) + ' ' + str(sum_of_white_pixels_global_delta//255) + ' ' + str(sum_of_white_pixels_global//255) + '\n')
                    file_for_one_file.write('{} {} {} {} {} {} {} \n'.format(str(frame_no), sum_of_white_pixels_global_delta//255, sum_of_white_pixels_global//255, sum_of_white_pixels_top_delta//255, sum_of_white_pixels_top//255, sum_of_white_pixels_bot_delta//255, sum_of_white_pixels_bot//255))

                frame_no += 1

            else:
                break
        #file_for_one_file.write('Sum: ' + str(full_sum_of_white_pixels_global_delta//255) + ' ' + str(full_sum_of_white_pixels_global//255) + '\n')
        #file_for_one_file.write('Sum: {} {} {} {} {} {} \n'.format(full_sum_of_white_pixels_global_delta//255, full_sum_of_white_pixels_global//255, full_sum_of_white_pixels_top_delta//255, full_sum_of_white_pixels_top//255, full_sum_of_white_pixels_bot_delta//255, full_sum_of_white_pixels_bot//255))
        file_for_one_file.close()
        print('file: ' + str(filez[file_no]) + ' ' + str(file_no+1) + '/' + str(len(filez)) + '\n')
        #file_for_all_analysis.write(str(filez[file_no]) + ' ' + str(file_no) + ' ' + str(full_sum_of_white_pixels_global_delta//255) + ' ' + str(full_sum_of_white_pixels_global//255) + '\n')
        file_for_all_analysis.write('{} {} {} {} {} {} {} {} \n'.format(str(filez[file_no]), str(file_no), full_sum_of_white_pixels_global_delta//(255*frame_no), full_sum_of_white_pixels_global//(255*frame_no), full_sum_of_white_pixels_top_delta//(255*frame_no), full_sum_of_white_pixels_top//(255*frame_no), full_sum_of_white_pixels_bot_delta//(255*frame_no), full_sum_of_white_pixels_bot//(255*frame_no)))

        file_no += 1
    file_for_all_analysis.close()
    tk.messagebox.showinfo(title='Done!', message='Done!')
#==========================================================================================================================================================


        # Release video object
    cap.release()

        # Destroy all windows
##==================================================================== < Графика >
window = Tk()
window.title("DanioTracker v0.1")
window.geometry('500x144')
Btn_for_load = Button(window, text="Выбрать файлы для чтения", command=Btn_for_load_Сlicked)
Btn_for_load.grid(column=1, row=0)
Btn_for_Global_mask = Button(window, text="Global Mask", command=Btn_for_Global_mask_Сlicked)
Btn_for_Global_mask.grid(column=2, row=6)
Btn_for_Mask_1 = Button(window, text="Mask 1", command=Btn_for_mask_1_Сlicked)
Btn_for_Mask_1.grid(column=3, row=6)
Btn_for_Mask_2 = Button(window, text="Mask 2", command=Btn_for_mask_2_Сlicked)
Btn_for_Mask_2.grid(column=4, row=6)
"""Btn_for_Floor = Button(window, text="floor", command=Btn_for_floor_Сlicked) # ==========================================
Btn_for_Floor.grid(column=5, row=6) # ==========================================
"""
Btn_for_start = Button(window, text="Start!", command=Btn_for_start_Clicked)
Btn_for_start.grid(column=0, row=6)

Btn_for_screenshot = Button(window, text="Screenshot", command=Btn_for_screenshot_Clicked)
Btn_for_screenshot.grid(column=1, row=6)

#lbl = Label(window, text="Порог контрастности")
#lbl.grid(column=0, row=5)
""""
var_for_spin = IntVar()
var_for_spin.set(150)
spin = Spinbox(window, from_=0, to=255, width=5, textvariable = var_for_spin, command = spin_value_changed)
spin.grid(column=1, row=5)
"""""

#rad1 = Radiobutton(window, text='Threshold', value=0)
#rad2 = Radiobutton(window, text='Global mask', value=1)

#rad1.grid(column=6, row=5)
#rad2.grid(column=6, row=6)


##=============================================================== </графика Логика>
#file_no = 0
#frame_no = 0
ret = False
frame = None
cap = None
frame = None
thresh_binared = None

window.protocol("WM_DELETE_WINDOW", on_closing)
window.mainloop()
cv2.destroyAllWindows()


cv2.waitKey(0)