import cv2
import mediapipe as mp
import os
import sys
sys.path.append(r'D:\Project\Mixed_Realaity_Project\mixed_reality_project_python\Python_scripts')
import mediapipe_video

label = 'cool'
output_dir = r'D:\Project\Mixed_Realaity_Project\mixed_reality_project_python\Python_scripts\training_gesture_recognition\dataset'
hand = 'right'
filename = label + '_' + hand + '.txt'


output_file = open(filename, 'w')

if __name__ == "__main__":
    
    mediapipe_module = mediapipe_video.Media_pipe()

    cap = cv2.VideoCapture(1)

    while True:

        ret, frame = cap.read()

        if (ret):

            frame_copy = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
            frame_copy = cv2.flip(frame_copy)

            results = mediapipe_module.perform_landmark_detection(frame_copy)

            print(results.multi_handedness)

        else:
            break

        cv2.imshow("Framwa", frame)

        if(cv2.waitKey(1) == 27):
            break

