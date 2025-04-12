' Extracts and evaluates Bit 0 from the input word (Me.stsWord).
' If Bit 0 is set (i.e., not equal to 0), the corresponding alarm attribute (Me.almAlarm001) is triggered.
' Otherwise, the alarm is cleared.

if ((Me.stsWord & (1 SHL 0)) <> 0) then
    Me.almXXX = true;
else
    Me.almXXX = false;
endif;
