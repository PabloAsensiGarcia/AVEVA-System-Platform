'------------------------------------------------------------------------------------
' This script reconstructs a 32-bit IEEE 754 floating-point number from two 16-bit 
' Modbus registers (MDBReg1 and MDBReg2) and assigns the resulting float value to 
' the specified object attribute.
'
' Step-by-step:
' 1. Me.MDBReg2 is shifted left by 16 bits to occupy the higher word of a 32-bit integer.
' 2. Bitwise OR (|) merges Me.MDBReg2 and Me.MDBReg1 into a single 32-bit value.
'    - This assumes the device sends the float as: HighWord (MDBReg2), LowWord (MDBReg1).
'    - If your device uses the reverse order, swap the registers accordingly.
' 3. System.BitConverter.GetBytes(...) converts the 32-bit integer into a 4-byte array.
' 4. System.BitConverter.ToSingle(..., 0) interprets that byte array as an IEEE 754 float.
' 5. The float is assigned to Me.Attribute for further use in logic, display, or alarms.
'
' This method is commonly used in Modbus communications where float values are transmitted
' across two consecutive 16-bit registers. It ensures the correct interpretation of the
' encoded value within System Platform despite its limited native data type support.
'------------------------------------------------------------------------------------

Me.Attribute = System.BitConverter.ToSingle(System.BitConverter.GetBytes((Me.MDBReg2 shl 16 | Me.MDBReg1)), 0);
