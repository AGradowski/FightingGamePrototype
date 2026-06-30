# Input Scripts

The folder for containg the documentation for anything relaed to the scripts connected to the Input Systems

## InputBuffer

The object responsible for holding the inputs from all the frames, in a LinkedList, for the purposes of motion inputs and keeping the input "live" for some number of frames. <b>ASSUME 60 FPS LOCK</b>

### Variables

* public LinkedList<FrameInput> inputHistory - the linked list containing the inputs from the last <i>sizeOfBuffer</i> frames
* public int sizeOfBuffer - the maximum size of the buffer

### Functions

* public void addInput(FrameInput input) - add the <i>input</i> to the inputHistory. If the size would exceed the sizeOfBuffer, remove the last (the oldest) input.
* public void clearInput() - creates new, empty inputHistory <i>remove?</i>
* public bool containsMotionInput(string input) - checks, if any given input is present at the moment in the input history. Input needs to be formatted properly, with 1-9 for directions, LP, RP, LK, RK for the attack inputs, and ":" symbol to seperate motion from attack input. Returns true, if there is a substring present same as given input.

## InputInterpreter

The player component that handles the inputs of each player

### Variables

### Functions

## FrameInput
