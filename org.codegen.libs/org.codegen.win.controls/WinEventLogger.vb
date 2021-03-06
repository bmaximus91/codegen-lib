'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
' 
' THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'---------------------------------------------------------------------

Public NotInheritable Class WinEventLogger

    Private Const LOG_NAME As String = "Application"

    Public Shared cEventSource As String

    Public Shared Sub WriteError(ByVal errorMessage As String)
        Try

            If String.IsNullOrEmpty(cEventSource) Then
                MsgBox("You must set a value to variable cEbentSource")
                Exit Sub
            End If

            'the event source should be created during the installation process
            If EventLog.SourceExists(cEventSource) Then

                'write the message as an error
                Using msg As EventLog = New EventLog(LOG_NAME)
                    msg.Source = cEventSource
                    msg.WriteEntry(errorMessage, EventLogEntryType.Error)
                End Using
            Else
                'try to create the event source for the next error (this requires admin rights)
                EventLog.CreateEventSource(cEventSource, LOG_NAME)
            End If
        Catch e As Exception
            MsgBox("Error in WinEventLogger.WriteError, while trying to write to log: [" & _
                   LOG_NAME & "." & cEventSource & "]" & _
                   e.Message & _
                   "Original Error Message:" & errorMessage, _
                   MsgBoxStyle.Exclamation, cEventSource)
        End Try
    End Sub

    Public Shared Sub WriteInfo(ByVal errorMessage As String)
        Try

            If String.IsNullOrEmpty(cEventSource) Then
                MsgBox("You must set a value to variable cEbentSource")
                Exit Sub
            End If

            'the event source should be created during the installation process
            If EventLog.SourceExists(cEventSource) Then

                'write the message as an error
                Using msg As EventLog = New EventLog(LOG_NAME)
                    msg.Source = cEventSource
                    msg.WriteEntry(errorMessage, EventLogEntryType.Information)
                End Using

            Else
                'try to create the event source for the next error (this requires admin rights)
                EventLog.CreateEventSource(cEventSource, LOG_NAME)
            End If
        Catch e As Exception
            MsgBox("Error in WinEventLogger.WriteInfo , while trying to write to log: [" & _
                   LOG_NAME & "." & cEventSource & "]" & _
                   e.Message & _
                   "Original Info Message:" & errorMessage, _
                   MsgBoxStyle.Exclamation, cEventSource)
        End Try
    End Sub

    Public Shared Sub WriteError(ByVal e As Exception)

        Dim msg As String = e.Message & vbCrLf & _
                        "Stack Trace:" & _
                                        e.StackTrace

        Call WriteError(msg)

    End Sub

End Class
