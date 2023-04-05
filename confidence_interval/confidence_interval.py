import numpy as np
import tkinter as tk
import tkinter.filedialog as fd
import tkinter.messagebox as mb
from tkinter import *
import numpy as np, scipy.stats as st

root = tk.Tk()
root.withdraw()
array_of_data = []

final_array = []

counter_of_missing_lines = 0
############
#a = 1.0 * np.array(data)
#n = len(array_of_data)
#m, se = np.mean(array_of_data), scipy.stats.sem(array_of_data)
#h = se * scipy.stats.t.ppf((1 + confidence) / 2., n-1)
#return m, m-h, m+h

###########
filez = fd.askopenfilenames(parent=root, title='Choose a file', filetypes = (("Текстовые файлы", "*.txt"),))
fileout = open(filez[-1]+"filez_Analysed.txt", 'w')
for file in filez:
    with open(file, 'r') as fp:
        array_of_data = fp.readlines()
        array_of_delta = []
        array_of_syl = []
        array_of_delta_top = []
        array_of_syl_top = []
        array_of_delta_bot = []
        array_of_syl_bot = []
        line_to_split = []
#===========================================================================================================================
        lines_to_mean = []
        for line in array_of_data:
            line_to_split = line.split()
            array_of_delta.append(line_to_split[1])
            array_of_syl.append(line_to_split[2])
            array_of_delta_top.append(line_to_split[3])
            array_of_syl_top.append(line_to_split[4])
            array_of_delta_bot.append(line_to_split[5])
            array_of_syl_bot.append(line_to_split[6])
        array_of_delta = list(map(int, array_of_delta))
        array_of_syl = list(map(int, array_of_syl))
        array_of_delta_top = list(map(int, array_of_delta_top))
        array_of_syl_top = list(map(int, array_of_syl_top))
        array_of_delta_bot = list(map(int, array_of_delta_bot))
        array_of_syl_bot = list(map(int, array_of_syl_bot))
        #print (np.mean(array_of_delta[0:-1]))


        n = len(array_of_delta)
        delta_mean, se = np.mean(array_of_delta), st.sem(array_of_delta)
        se = np.std(array_of_delta)
        h_delta = se * st.t.ppf((1 + 0.9973) / 2., n-1)

        for line in array_of_data:
            line_to_analyse = line.split()
            if  (float(line_to_analyse[1])) < delta_mean+h_delta and (float(line_to_analyse[1]) > delta_mean-h_delta):
                lines_to_mean.append(line_to_analyse)
            else:
                counter_of_missing_lines +=1
        #fileout.write(f"{file} {str(np.mean(array_of_delta))} {str(np.mean(array_of_syl))} {str(np.mean(array_of_delta_top))} ")
        if file.endswith("09-00.avi.txt"):
            fileout.write("\n")
        fileout.write(f"{file} {str(np.mean(array_of_delta))} {str(np.mean(array_of_syl))} {str(np.mean(array_of_delta_top))} {str(np.mean(array_of_syl_top))} {str(np.mean(array_of_delta_bot))} {str(np.mean(array_of_syl_bot))}\n")
        print (counter_of_missing_lines, len(array_of_delta))
fileout.close()
#=========================================================================================================================================================




#print(array_of_delta)

"""    while len(strin) > 3:
        strin = Fin.readline()
        if len(strin) > 3 :
            array_of_data.append(strin)
            #print(strin)
            array_of_delta.append(strin[1])
            array_of_syl.append(strin[1])

print (array_of_data)
print (array_of_delta)
print (array_of_syl)

print (len(array_of_data))
print (len(array_of_delta))
print (len(array_of_syl))
"""
#Fin.close()
#f = open( file + '_edited.txt', 'w' )
#f.close()

