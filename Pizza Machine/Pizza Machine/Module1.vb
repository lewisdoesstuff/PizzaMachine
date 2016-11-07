'{Program Property Of Lewis Wood ( For Reals This Time ) }

Imports System.Text 'system.text to find length of var
Module Module1
    Dim name As String
    Dim address As String
    Dim pnum As String
    Dim amount As String
    Dim pamount As UInteger 'declarations
    Dim pizzafinal(19) As String
    Dim pprice(19) As String
    Dim cost As UInteger
    Dim menulist = {"1.Cheese & Tomato – Italian-style six-cheese blend – £7.50",
"2.BBQ Chicken – Chargrilled chicken, barbeque sauce, bacon, onions – £7.90",
"3.Meat Feast – Ham, peperoni, sausage, bacon, spicy beef – £8.10",
"4.Piri-Piri Chicken – Chilli pepper sauce, chargrilled chicken – £8.80", ' menu in array
"5.Hawaii – Ham, pineapple, mushrooms – £8.90",
"6.Mediterranean – Chorizo, Italian-style sausage, jalapeno sausage – £9.50",
"7.The Mexican – Jalapeno peppers, red peppers, spicy beef, onions – £9.70",
"8.The Works – Pepperoni, sausage, ham, mushrooms, green peppers – £9.90"}
    Sub Main()
        Console.WriteLine("Pizza App v2")
        getname()
        getaddress()
        getpnum() ' calling functions ( makes the program modular and easier to read/debug imo
        getorder()
        math()
        recipt()

    End Sub
    Public Function getname()
        Console.WriteLine("Please enter your name")
        name = Console.ReadLine() ' get name
        Console.Clear()
        Return True
    End Function
    Public Function getaddress()
        Console.WriteLine("Please enter your address")
        address = Console.ReadLine()
        Console.Clear()
        Return True ' same as name but with address var
    End Function
    Public Function getpnum()
        Console.WriteLine("Please enter your phone number (inc area code)")
        pnum = Console.ReadLine()
        If IsNumeric(pnum) AndAlso (pnum.Length >= 11 AndAlso pnum.Length <= 12) Then ' same as before, check numericalicy(probably not a word) and length to be 11 or 12
            Return True
        Else
            Console.WriteLine("Incorrect entry, check it's a numerical value and its the correct length (11-12 digits)")
            Threading.Thread.Sleep(2000)
            getpnum() ' error!
            Return False
        End If
    End Function
    Public Function getorder()
        For Each line As String In menulist
            Console.WriteLine(line) ' print menu
        Next
        Console.WriteLine("How many pizzas do you want?")
        amount = Console.ReadLine() ' get order amount
        If IsNumeric(amount) AndAlso amount <= 20 Then ' check numericalicy and length
            pamount = amount
        Else
            Console.WriteLine("Incorrect value, check for numeric value and that it's less than 20") ' Error!
        End If
        Console.WriteLine("Enter your pizzas")
        pamount = (pamount - 1) ' do some math!
        For i As Integer = 0 To pamount
            pizzafinal(i) = Console.ReadLine() ' get pizza input
            If pizzafinal(i) > 8 Or IsNumeric(pizzafinal(i)) Then
            Else
                Console.WriteLine("Incorrect value, check it's not bigger than 8 and that it's numerical") ' again same as before
                Threading.Thread.Sleep(2000)
                getorder()
            End If
        Next
        Return True
    End Function
    Public Function math()
        Dim mathint As Integer
        For mathint = 0 To pamount
            If pizzafinal(mathint) = 1 Then
                pprice(mathint) = 7.5 ' huge ifElseif, probably could use a loop, too late at night for that.
                pizzafinal(mathint) = "Cheese & Tomato – Italian-style six-cheese blend"
            ElseIf pizzafinal(mathint) = 2 Then
                pprice(mathint) = 7.9
                pizzafinal(mathint) = "BBQ Chicken – Chargrilled chicken, barbeque sauce, bacon, onions"
            ElseIf pizzafinal(mathint) = 3 Then
                pprice(mathint) = 8.1
                pizzafinal(mathint) = "Meat Feast – Ham, peperoni, sausage, bacon, spicy beef"
            ElseIf pizzafinal(mathint) = 4 Then
                pprice(mathint) = 8.8
                pizzafinal(mathint) = "Piri-Piri Chicken – Chilli pepper sauce, chargrilled chicken"
            ElseIf pizzafinal(mathint) = 5 Then
                pprice(mathint) = 7.9
                pizzafinal(mathint) = "Hawaii – Ham, pineapple, mushrooms"
            ElseIf pizzafinal(mathint) = 6 Then
                pprice(mathint) = 7.9
                pprice(mathint) = "Mediterranean – Chorizo, Italian-style sausage, jalapeno sausage"
            ElseIf pizzafinal(mathint) = 7 Then
                pprice(mathint) = 7.9
                pizzafinal(mathint) = "The Mexican – Jalapeno peppers, red peppers, spicy beef, onions"
            ElseIf pizzafinal(mathint) = 8 Then
                pprice(mathint) = 7.9
                pizzafinal(mathint) = "The Works – Pepperoni, sausage, ham, mushrooms, green peppers"
            End If
        Next
        For mathint = 0 To pamount
            cost = cost + pprice(mathint) ' calculate the cost

        Next
        If cost > 20 Then
            cost = cost - (cost * 0.2) ' add discount (subtract?)

        End If
        If cost < 10 Then
            cost = cost + 1.5 ' delivery charge

        End If
        Return True
    End Function
    Function recipt()
        Console.Clear()
        Console.WriteLine("**********RECIPT**********")
        Console.WriteLine()
        For i As Integer = 0 To pamount
            Console.WriteLine(pizzafinal(i)) ' print the pizzas ordered nicely

        Next
        Console.WriteLine("Order Subtotal            £" & cost) ' print cost
        Console.ReadLine()
        Return True
    End Function
End Module
