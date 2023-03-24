Module Module1
    Dim rand As New Random
    Sub Main()

        PrintTitle()
        Console.WriteLine(vbNewLine & "Make sure you have the text you want to be made undetectable copied to your clipboard!")
        Console.Write("Press any key to continue. . .")
        Console.ReadKey()
        Dim firstReFormat = ReFormat(RemoveUnallowedChar())
        Dim secondReFormat = ReFormat(firstReFormat)
        My.Computer.Clipboard.SetText(secondReFormat)
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Green
        PrintSuccess()
        Console.WriteLine(vbNewLine & "Undetectable text successfully copied to clipboard!")
        Console.ForegroundColor = ConsoleColor.White
        Console.Write("Press any key to exit. . .")
        Console.ReadKey()
    End Sub

    Function random(mode)
        Dim num As Integer = rand.Next(0, 1001)
        If num >= 200 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function randomside()
        Dim num As Integer = rand.Next(0, 1001)
        If num >= 500 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function RemoveUnallowedChar()
        Dim original_text As Array = My.Computer.Clipboard.GetText().Split(" ")
        Dim reconstructed_text As String
        Dim count As Integer = 0
        For Each item In original_text
            If Not item = " " Then
                If count = 0 Then
                    reconstructed_text += item
                Else
                    reconstructed_text += " " & item
                End If
                count += 1
            End If
        Next
        Return reconstructed_text
    End Function

    Function amount() As Integer
        Dim num As Integer = rand.Next(0, 1001)
        If num >= 0 AndAlso num <= 799 Then
            Return 1
        ElseIf num >= 800 <= 900 Then
            Return 2
        ElseIf num >= 901 <= 1000 Then
            Return 3
        End If
    End Function

    Function ReFormat(original_text As String)
        Dim seperated_text As Array = original_text.Split(" ")
        Dim reconstructed_text As String = ""
        Dim punction() As String = {"""", "'", ",", ".", "?", "/", "+", "_", "-", "=", ">", "<", ":", ";", "\", "|", "`", "~", "*", "&", "^", "%", "$", "#", "!", "@", "'s"}
        Dim char1 As String = "​"
        Dim char2 As String = "​"
        Dim char3 As String = "⁤"
        Dim currentchar = char1
        For i As Integer = 0 To 1
            For x As Integer = 0 To seperated_text.Length - 1
                If x > 0 Then
                    Dim last_word As String = seperated_text(x - 1)
                    Try
                        If punction.Contains(last_word(last_word.Length - 1)) OrElse punction.Contains(last_word(last_word.Length - 2)) Then
                            reconstructed_text += String.Format(" {0}", seperated_text(x))
                        Else
                            If random(i) Then
                                If randomside() Then
                                    For y As Integer = 0 To amount()
                                        reconstructed_text += currentchar
                                    Next
                                    reconstructed_text += " " & seperated_text(x)
                                Else
                                    reconstructed_text += " " & seperated_text(x)
                                    For y As Integer = 0 To amount()
                                        reconstructed_text += currentchar
                                    Next
                                End If
                            Else
                                reconstructed_text += String.Format(" {0}", seperated_text(x))
                            End If
                        End If
                    Catch ex As Exception
                        reconstructed_text += String.Format(" {0}", seperated_text(x))
                    End Try

                Else
                    reconstructed_text += seperated_text(x)
                End If
            Next
            If i = 0 Then
                currentchar = char2
                original_text = reconstructed_text
                reconstructed_text = ""
                If i = 1 Then
                    currentchar = char3
                    original_text = reconstructed_text
                    reconstructed_text = ""
                End If
            End If
        Next
        Return reconstructed_text
    End Function

    Sub PrintSuccess()
        Console.WriteLine("
.d88888b  dP     dP  a88888b.  a88888b.  88888888b .d88888b  .d88888b  
88.    ""' 88     88 d8'   `88 d8'   `88  88        88.    ""' 88.    ""' 
`Y88888b. 88     88 88        88        a88aaaa    `Y88888b. `Y88888b. 
      `8b 88     88 88        88         88              `8b       `8b 
d8'   .8P Y8.   .8P Y8.   .88 Y8.   .88  88        d8'   .8P d8'   .8P 
 Y88888P  `Y88888P'  Y88888P'  Y88888P'  88888888P  Y88888P   Y88888P  ")
        Console.ResetColor()
    End Sub

    Sub PrintTitle()
        Console.ForegroundColor = ConsoleColor.yellow
        Console.Write(" .d888888  dP          ")
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.WriteLine("888888ba   88888888b d888888P  88888888b  a88888b. d888888P dP  .88888.  888888ba ")
        Console.ForegroundColor = ConsoleColor.yellow
        Console.Write("d8'    88  88          ")
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.WriteLine("88    `8b  88           88     88        d8'   `88    88    88 d8'   `8b 88    `8b")
        Console.ForegroundColor = ConsoleColor.yellow
        Console.Write("88aaaaa88a 88          ")
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.WriteLine("88     88 a88aaaa       88    a88aaaa    88           88    88 88     88 88     88")
        Console.ForegroundColor = ConsoleColor.yellow
        Console.Write("88     88  88          ")
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.WriteLine("88     88  88           88     88        88           88    88 88     88 88     88")
        Console.ForegroundColor = ConsoleColor.yellow
        Console.Write("88     88  88          ")
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.WriteLine("88    .8P  88           88     88        Y8.   .88    88    88 Y8.   .8P 88     88")
        Console.ForegroundColor = ConsoleColor.yellow
        Console.Write("88     88  dP          ")
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.WriteLine("8888888P   88888888P    dP     88888888P  Y88888P'    dP    dP  `8888P'  dP     dP")
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("
 888888ba  dP    dP  888888ba   .d888888  .d88888b  .d88888b   88888888b  888888ba  
 88    `8b Y8.  .8P  88    `8b d8'    88  88.    ""' 88.    ""'  88         88    `8b
a88aaaa8P'  Y8aa8P  a88aaaa8P' 88aaaaa88a `Y88888b. `Y88888b. a88aaaa    a88aaaa8P' 
 88   `8b.    88     88        88     88        `8b       `8b  88         88   `8b. 
 88    .88    88     88        88     88  d8'   .8P d8'   .8P  88         88     88 
 88888888P    dP     dP        88     88   Y88888P   Y88888P   88888888P  dP     dP 
")
        Console.ResetColor()
    End Sub


End Module
