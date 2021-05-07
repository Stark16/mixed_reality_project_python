import cv2
import mediapipe as mp
import time

        
if __name__ == "__main__":

    img_path = r"D:\Project\Mixed_Realaity_Project\Python_Parts\data\images\hands.jpg"    
    
    # Preprocessing:

    img = cv2.imread(img_path)
    img = cv2.flip(img, 1)
    img = cv2.resize(img, (600, 600))
    img = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)


    # Initializing mp objects:
    
    mp_drawwings = mp.solutions.drawing_utils
    mp_hands = mp.solutions.hands

    hands = mp_hands.Hands(static_image_mode=True, max_num_hands = 2, min_detection_confidence=0.5)
    

    # get the results:

    t1 = time.time()

    results = hands.process(img)
    
    print("[INFO] Time to process 1 image: {}".format((time.time() - t1)))
    #print("[INFO] Finger Join Landmarks: {}".format(results.multi_hand_landmarks))

    if not (results.multi_hand_landmarks):
        print("No Hand Found")
        exit(-1)

    for landmarks in results.multi_hand_landmarks:
        #print(
        #  f'Index finger tip coordinates: (',
        #  f'{landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_TIP].x}, '
        #  f'{landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_TIP].y})'
        #    )

        mp_drawwings.draw_landmarks(img, landmarks, mp_hands.HAND_CONNECTIONS)


    # Display:
    cv2.imshow("img", img)
    cv2.waitKey(0)
