'Lewis Wood
Imports System.Text ' system.text for getting .length (don't know why this isn't native but whatever)
Module Module1
    Dim name As String
    Dim address As String
    Dim phonenumber As String
    Dim pizza(19) As String
    Dim pizzaprice(19) As String ' all my variables and arrays, mostly as strings becuase isnumeric()
    Dim pizzaamount As Integer
    Dim cost As Decimal
    Dim payment As String
    Dim cnumber As String
    Dim code As String
    Dim stringammount As String
    Dim menulist = {"1.Cheese & Tomato – Italian-style six-cheese blend – £7.50",
"2.BBQ Chicken – Chargrilled chicken, barbeque sauce, bacon, onions – £7.90",
"3.Meat Feast – Ham, peperoni, sausage, bacon, spicy beef – £8.10",
"4.Piri-Piri Chicken – Chilli pepper sauce, chargrilled chicken – £8.80",
"5.Hawaii – Ham, pineapple, mushrooms – £8.90",
"6.Mediterranean – Chorizo, Italian-style sausage, jalapeno sausage – £9.50",
"7.The Mexican – Jalapeno peppers, red peppers, spicy beef, onions – £9.70",
"8.The Works – Pepperoni, sausage, ham, mushrooms, green peppers – £9.90"} ' store all the pizzas in an array
    Sub Main()
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine("Hello and welcome to Jimmys Pizza")
        getname()
        getaddress()
        getphonenumber() ' calling all the functions
        menu()
        calc()
        total()
        pay()
        recipt()
    End Sub
    Function getname()
        Console.ForegroundColor = ConsoleColor.Yellow
        ' Console.TreatControlCAsInput = True ' ~~stops people ^C-ing to crash it~~ okay, so it turns out that microsoft haven't fixed a bug from 2006 which breaks loops if this is true. 10 YEARS GUYS.

        Console.WriteLine("May i take your name?")
        name = Console.ReadLine() ' store name in name variable
        Return True ' returns true becuase you can't really mess up typing a bunch of letters
        Console.Clear()
    End Function
    Function getaddress()
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("May i take your address?") ' same thing with address
        address = Console.ReadLine()
        Return True
    End Function
    Function getphonenumber()
        Console.ForegroundColor = ConsoleColor.Magenta
        Console.Clear()
        Console.WriteLine("May i take your phone number? Please include the area code if it is a landline")
        phonenumber = Console.ReadLine()
        If IsNumeric(phonenumber) AndAlso phonenumber.Length > 10 And phonenumber.Length < 13 Then ' checks if the phonenumber is 11 or 12 digits and is a numeric value
            Return True
        Else
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Incorrect Phone Number, Try Again.")
            getphonenumber()
            Return False
        End If
    End Function
    Function menu()
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.DarkCyan
        For Each line As String In menulist
            Console.WriteLine(line) ' prints the menu
        Next
        Console.ForegroundColor = ConsoleColor.Blue
        Console.WriteLine("Please enter how many pizzas you would like to order") ' gets how many pizzas they want
        stringammount = Console.ReadLine()
        If IsNumeric(stringammount) Then
            pizzaamount = stringammount
        Else
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Incorrect value")
            Threading.Thread.Sleep(2000)
            menu()
        End If
        If pizzaamount <= 20 Then ' check that its less than/equal to 20
        Else
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Incorrect value")
            Threading.Thread.Sleep(2000)
            menu()
        End If
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("Enter your pizzas:")
        pizzaamount = pizzaamount - 1
        For i As Integer = 0 To pizzaamount ' gets the pizzas and stores them in pizza(19)
            pizza(i) = Console.ReadLine
            If pizza(i) > 8 Or IsNumeric(pizza(i)) Then
            Else
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Incorect value")
                Threading.Thread.Sleep(2000)
                menu()
            End If
        Next
        Return True
    End Function
    Function calc()
        Console.Clear()

        Dim potato As Integer
        For potato = 0 To pizzaamount ' probably inefficiant but it works
            If pizza(potato) = 1 Then ' if its 1, then put price to 7.5 and add the name of the pizza to the array
                pizzaprice(potato) = 7.5
                pizza(potato) = "Cheese & Tomato – Italian-style six-cheese blend"
            ElseIf pizza(potato) = 2 Then
                pizzaprice(potato) = 7.9
                pizza(potato) = "BBQ Chicken – Chargrilled chicken, barbeque sauce, bacon, onions"
            ElseIf pizza(potato) = 3 Then
                pizzaprice(potato) = 8.1
                pizza(potato) = "Meat Feast – Ham, peperoni, sausage, bacon, spicy beef"
            ElseIf pizza(potato) = 4 Then
                pizzaprice(potato) = 8.8
                pizza(potato) = "Piri-Piri Chicken – Chilli pepper sauce, chargrilled chicken"
            ElseIf pizza(potato) = 5 Then
                pizzaprice(potato) = 7.9
                pizza(potato) = "Hawaii – Ham, pineapple, mushrooms"
            ElseIf pizza(potato) = 6 Then
                pizzaprice(potato) = 7.9
                pizzaprice(potato) = "Mediterranean – Chorizo, Italian-style sausage, jalapeno sausage"
            ElseIf pizza(potato) = 7 Then
                pizzaprice(potato) = 7.9
                pizza(potato) = "The Mexican – Jalapeno peppers, red peppers, spicy beef, onions"
            ElseIf pizza(potato) = 8 Then
                pizzaprice(potato) = 7.9
                pizza(potato) = "The Works – Pepperoni, sausage, ham, mushrooms, green peppers"
            End If
        Next
        For potato = 0 To pizzaamount
            cost = cost + pizzaprice(potato) ' add all the costs
        Next
        If cost > 20 Then
            cost = cost - (cost * 0.2)
        End If
        If cost < 10 Then
            cost = cost + 1.5
        End If
        Return True
    End Function
    Function total()
        Console.ForegroundColor = ConsoleColor.Cyan
        Math.Round(cost, 2, MidpointRounding.AwayFromZero) ' round the number incase of decimal madness
        Console.WriteLine("The cost of the pizza is £" & cost)
        Return True
    End Function
    Function pay()
        Console.ForegroundColor = ConsoleColor.Blue
        Console.WriteLine("How would you like to pay?")
        Console.WriteLine("")
        Console.WriteLine("1. Card") ' get payment method
        Console.WriteLine("2. On Delivery")
        payment = Console.ReadLine
        If payment = 2 Then
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("Please have £" & cost & " ready at the door")
            Threading.Thread.Sleep(2000)
        ElseIf payment = 1 Then
            Console.ForegroundColor = ConsoleColor.White
            Console.WriteLine("Please enter your card number (16 digit)")
            cnumber = Console.ReadLine()
            Console.ForegroundColor = ConsoleColor.Green
            If IsNumeric(cnumber) AndAlso cnumber.Length = 16 Then 'check for card length and numericness
                Console.WriteLine("Please enter the 3 digit CVC number (Found on the back)") ' get CVC code
                code = Console.ReadLine()
                If IsNumeric(code) AndAlso code.Length = 3 Then ' check length and numericness
                    Return True
                Else
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine("That was incorrect, Please try again")
                    Threading.Thread.Sleep(2000)
                    pay()
                    Return False
                End If ' tell them they're wrong
            Else
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("That was incorrect, Please try again")
                Threading.Thread.Sleep(2000)
                pay()
                Return False
            End If
        End If
        Return True
    End Function
    Function recipt()
        Console.ForegroundColor = ConsoleColor.Green
        Console.Clear()
        Console.WriteLine("~~~~~~~~~~~~~~~RECIPT~~~~~~~~~~~~~~~")
        Console.WriteLine("")
        For i As Integer = 0 To pizzaamount ' print the recipt and all their pizzas
            Console.WriteLine(pizza(i))
        Next
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine("Order Cost:              £" & cost)
        Console.WriteLine("Order Number:           " & GenerateRandomString(6, False)) ' get a random number, 6 characters with no uppercase
        Console.ReadLine()
        Return True
    End Function

    Public Function GenerateRandomString(ByRef len As Integer, ByRef upper As Boolean) As String
        Dim rand As New Random()
        Dim allowableChars() As Char = "ABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789".ToCharArray()
        Dim final As String = String.Empty
        For i As Integer = 0 To len - 1 ' random number generator courtesy of stackoverflow
            final += allowableChars(rand.Next(allowableChars.Length - 1))
        Next
        Return IIf(upper, final.ToUpper(), final)
    End Function
End Module
