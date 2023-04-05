import numpy as np
import tkinter as tk
import tkinter.filedialog as fd
import tkinter.messagebox as mb
from tkinter import *

list_of_frames = []
str_split = []
avg_value = 0
total_values = 0
sum_of_sd_values = 0
zero_frames = 0

iters_counter = 0
list_of_lists = [[]]
list_of_dates = []

root = tk.Tk()
root.withdraw()
filez = fd.askopenfilenames(parent=root, title='Choose a file', filetypes = (("Текстовые файлы", "*.txt"),))

list_of_lists.remove([])
for file in filez:
    Fin = open (file, 'r')
    while True:
        strin = Fin.readline()
        if not strin: break
        str_split = strin.split()
        if len(str_split) > 3:
            #print(str_split[-7])
            if str_split[-7][-13:-8] not in list_of_dates:
                list_of_dates.append(str_split[-7][-13:-8])
                list_of_lists.append(str_split)
                list_of_lists[-1].append(1)
            else:
                for item in list_of_lists:
                    #print(item[1][-13:-8])
                    if str_split[-7][-13:-8] == item[1][-13:-8]:
                        item[-1] = int(item[-1]) + 1
                        iters_counter+=1
                        item[-2] = float(item[-2]) + float(str_split[-1])
                        item[-3] = float(item[-3]) + float(str_split[-2])
                        item[-4] = float(item[-4]) + float(str_split[-3])
                        item[-5] = float(item[-5]) + float(str_split[-4])
                        item[-6] = float(item[-6]) + float(str_split[-5])
                        item[-7] = float(item[-7]) + float(str_split[-6])
                        #print(str_split[-7] in item)

#print (list_of_lists)
print (list_of_dates)
#print (iters_counter)

f = open( file + '_calculated.txt', 'w' )
list_of_lists = sorted(list_of_lists, reverse=False, key=lambda x: x[0])
for item in list_of_lists:
    if len(item)>1:

        item[1] = item[1][-13:-8]
        item[-2] = float(item[-2]) / int(item[-1])
        item[-3] = float(item[-3]) / int(item[-1])
        item[-4] = float(item[-4]) / int(item[-1])
        item[-5] = float(item[-5]) / int(item[-1])
        item[-6] = float(item[-6]) / int(item[-1])
        item[-7] = float(item[-7]) / int(item[-1])

        print (item)
        f.write(str(item[-8:-1]).replace(',','').replace('[','').replace(']','').replace('\'','') + '\n')
#print(list_of_lists)
f.close()

Fin.close()