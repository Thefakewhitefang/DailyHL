Public Class Form1
    Dim User As String = Environ$("userprofile")
    Dim Today As String = String.Format("{0:MM/dd/yyyy}", DateTime.Now)
    Dim DateCheck As String = System.IO.File.ReadAllText(User & "\Documents\DailyHL\date.txt")
    Dim Days As String = System.IO.File.ReadAllText(User & "\Documents\DailyHL\days.txt")

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "Today is: " & Today
        'Give todays date in MM/DD/YYYY format
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call DateChecker()
        Call RenderDate()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        MsgBox(String.Format("{0:dd/MM/yyyy}", DateTime.Now), , "Date")
        'Gives date in standard format
    End Sub

    Sub DateChecker()
        If Today <> DateCheck Then
            MsgBox("Writing Day: " & Days + 1, , "Daily Half Life 3 Update!")
            'Output the day of updating the current days file
            System.IO.File.WriteAllText(User & "\Documents\DailyHL\date.txt", Today)
            System.IO.File.WriteAllText(User & "\Documents\DailyHL\days.txt", Days + 1)
        Else
            MsgBox("Writing Day: " & Days, , "Daily Half Life 3 Update!")
            'Output the same day if reopened
        End If
    End Sub

    Sub RenderDate()
        Days = System.IO.File.ReadAllText(User & "\Documents\DailyHL\days.txt")
        'Update the variable in case it is changed by DateChecker

        Dim Template As Bitmap = My.Resources.Template
        Dim Artist As Graphics = Graphics.FromImage(Template)
        Dim DrawBrush As New SolidBrush(Color.Black)
        Dim Font As New Font("Dailyhl", 60)
        Dim TypePoint As New Point(229, 169)

        Artist.DrawString(Days, Font, DrawBrush, TypePoint)
        Template.Save("DailyHL.png", System.Drawing.Imaging.ImageFormat.Png)
        Process.Start("DailyHL.png")
    End Sub
End Class
