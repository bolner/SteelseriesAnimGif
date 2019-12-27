OLED gif generator for Steelseries keyboards
============================================

This tool generates anim GIFs that can be outputted on the OLED display
of Steelseries keyboards. It creates a scrolling / repeating animation
from any string input.

# Samples

Bits:

![Bits](samples/bits.gif)

Math:

![Bits](samples/math.gif)

# Character map for escape sequences

The input text can contain escape sequences, for example:

    \001 + \002 = \007

Use them if one of the characters you typed doesn't render properly, or if you would like to use a special character.

![Character map](doc/chart.png)

# Usage

Just pass the path to the text file as the first parameter:

    dotnet run samples/bits.txt

It will create a file in the same folder and with the same name but with '.gif' extension.