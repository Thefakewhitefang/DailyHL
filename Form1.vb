Public Class Form1
    Dim User As String = Environ$("userprofile")
    Dim Today As String = String.Format("{0:MM/dd/yyyy}", DateTime.Now)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "Today is: " & Today
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DateCheck As String = System.IO.File.ReadAllText(User & "\Documents\DailyHL\date.txt")
        Dim Days As String = System.IO.File.ReadAllText(User & "\Documents\DailyHL\days.txt")

        Dim Template As Bitmap = My.Resources.Template
        Dim G As Graphics = Graphics.FromImage(Template)
        Dim DrawBrush As New SolidBrush(Color.Black)
        Dim Font As New Font("Dailyhl", 60)


        If Today <> DateCheck Then
            MsgBox("Writing Day: " & Days + 1, , "Daily Half Life 3 Update!")
            System.IO.File.WriteAllText(User & "\Documents\DailyHL\date.txt", Today)
            System.IO.File.WriteAllText(User & "\Documents\DailyHL\days.txt", Days + 1)
        Else
            MsgBox("Writing Day: " & Days, , "Daily Half Life 3 Update!")
        End If
        Days = System.IO.File.ReadAllText(User & "\Documents\DailyHL\days.txt")

        G.DrawString(Days, Font, DrawBrush, New Point(229, 169))
        Template.Save("DailyHL.png", System.Drawing.Imaging.ImageFormat.Png)

    End Sub
End Class
