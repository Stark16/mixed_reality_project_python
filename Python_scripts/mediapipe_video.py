import mediapipe as mp
import cv2
import time

class Media_pipe:

    def __init__(self):
        self.mp_drawwings = mp.solutions.drawing_utils
        self.mp_hands = mp.solutions.hands

        self.hands = self.mp_hands.Hands( max_num_hands = 2, min_detection_confidence=0.5)

    def perform_landmark_detection(self, frame):

        self.results = self.hands.process(frame)
        return self.results

    def draw_landmarks(self, frame, results):
        
        for landmark in results.multi_hand_landmarks:
            print(type(landmark))
            self.mp_drawwings.draw_landmarks(frame, landmark, self.mp_hands.HAND_CONNECTIONS)

        return frame

if __name__ == "__main__":
    
    cap = cv2.VideoCapture(1)
    media_pipe_module = Media_pipe()

    while(True):

        ret, frame = cap.read()

        if (ret):

            #frame = cv2.flip(frame, 1)
            frame_copy = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)

            results = media_pipe_module.perform_landmark_detection(frame_copy)

            if results.multi_hand_landmarks is not None:
                frame = media_pipe_module.draw_landmarks(frame, results)            

            cv2.imshow("Frame", frame)

            if (cv2.waitKey(1) == 27):
                break

        else:
            break
