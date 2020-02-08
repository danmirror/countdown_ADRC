
Imports System.Data.OleDb
Public Class Form1
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database_internal.accdb")
    Dim jam As Integer
    Dim menit As Integer
    Dim detik As Integer
    Dim count As Integer
    Dim cnt As Integer
    Dim cb1 As String
    Dim cb2 As String
    Dim cb3 As String
    Dim cb4 As String



    Dim dtk As Integer
    Dim change1 As Integer
    Dim change2 As Integer
    Dim change3 As Integer

    Dim cmd As New OleDbCommand
    Dim adapt As New OleDbDataAdapter

    Dim dt1 As New DataTable
    Dim dt2 As New DataTable
    Dim dt3 As New DataTable
    Dim dt4 As New DataTable
    Dim dt5 As New DataTable
    Dim dt6 As New DataTable
    Dim dt7 As New DataTable
    Dim dt8 As New DataTable

    Private Property cb As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadioButton4.Checked = True
        PictureBox1.Width = Me.Width
        PictureBox1.Height = Me.Height
        GroupBox3.Hide()
        GroupBox4.Hide()
        GroupBox10.Hide()
        GroupBox11.Hide()
        Label9.Hide()
        Label1.Text = "00:00:00"
        Label21.Text = "SET MODE"
        Button1.Enabled = False
        Button2.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button9.Enabled = False
        Button11.Enabled = False

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False

        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False

        TextBox7.Enabled = False
        TextBox8.Enabled = False
        TextBox9.Enabled = False
        TextBox1.Text = "03"
        TextBox2.Text = "00"
        TextBox3.Text = "00"

        TextBox4.Text = "00"
        TextBox5.Text = "30"
        TextBox6.Text = "00"

        TextBox7.Text = "00"
        TextBox8.Text = "30"
        TextBox9.Text = "00"
        OvalShape1.BackColor = Color.Maroon
        OvalShape2.BackColor = Color.DarkOrange
        OvalShape3.BackColor = Color.Olive
        OvalShape4.BackColor = Color.Green


        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "Select ID,NAMA from peserta"
            adapt.SelectCommand = cmd
            adapt.Fill(dt1)
            adapt.Fill(dt2)
            adapt.Fill(dt3)
            adapt.Fill(dt4)
            adapt.Fill(dt5)
            adapt.Fill(dt6)
            adapt.Fill(dt7)
            adapt.Fill(dt8)

            con.Close()
        Catch myerror As OleDbException
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            con.Dispose()
        End Try

        ComboBox1.DataSource = dt1
        ComboBox1.DisplayMember = "NAMA"
        ComboBox1.ValueMember = "ID"

        ComboBox2.DataSource = dt2
        ComboBox2.DisplayMember = "NAMA"
        ComboBox2.ValueMember = "ID"

        ComboBox3.DataSource = dt3
        ComboBox3.DisplayMember = "NAMA"
        ComboBox3.ValueMember = "ID"

        ComboBox4.DataSource = dt4
        ComboBox4.DisplayMember = "NAMA"
        ComboBox4.ValueMember = "ID"

        ComboBox5.DataSource = dt5
        ComboBox5.DisplayMember = "NAMA"
        ComboBox5.ValueMember = "ID"

        ComboBox6.DataSource = dt6
        ComboBox6.DisplayMember = "NAMA"
        ComboBox6.ValueMember = "ID"

        ComboBox7.DataSource = dt7
        ComboBox7.DisplayMember = "NAMA"
        ComboBox7.ValueMember = "ID"

        ComboBox8.DataSource = dt8
        ComboBox8.DisplayMember = "NAMA"
        ComboBox8.ValueMember = "ID"

    End Sub

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        dtk = dtk - 1
        If dtk < 0 Then
            Label1.Show()
            Label9.Hide()
            Timer2.Enabled = True
        End If
        If dtk = -3 Then
            If RadioButton2.Checked = True Then
                My.Computer.Audio.Play(My.Resources.trial_mi,
        AudioPlayMode.Background)
            End If
        ElseIf dtk = 0 Then
            Label9.Text = Format(dtk)
            OvalShape1.BackColor = Color.Lime
            OvalShape2.BackColor = Color.Lime
            OvalShape3.BackColor = Color.Lime
            OvalShape4.BackColor = Color.Lime
            If RadioButton3.Checked = False Then
                My.Computer.Audio.Play(My.Resources.gong,
    AudioPlayMode.Background)
            End If
        ElseIf dtk = 1 Then
            Label9.Text = Format(dtk)
            OvalShape2.BackColor = Color.Empty
            OvalShape3.BackColor = Color.Yellow
        ElseIf dtk = 2 Then
            Label9.Text = Format(dtk)
            OvalShape1.BackColor = Color.Empty
            OvalShape2.BackColor = Color.OrangeRed
        ElseIf dtk <= 5 Then
            Label9.Text = Format(dtk)
        ElseIf dtk = 6 Then
            If RadioButton2.Checked = True Or RadioButton1.Checked = True Then
                My.Computer.Audio.Play(My.Resources.start,
    AudioPlayMode.Background)
            End If
        End If

    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        detik = detik - 1
        If detik < 0 Then
            detik = 63
            menit = menit - 1
        Else
            If menit < 0 Then
                menit = 59
                jam = jam - 1
            End If
        End If
        Label1.Text = Format(jam, "00") & ":" & Format(menit, "00") & ":" & Format(detik, "00")
        If jam = 0 And menit = 0 And detik = 0 Then
            My.Computer.Audio.Play(My.Resources.buzzer1,
    AudioPlayMode.Background)
            Timer1.Enabled = False
            Timer2.Enabled = False
            Button1.Enabled = True
            Button1.BackColor = Color.Lime
            Button2.Enabled = False
            Button2.BackColor = Color.Firebrick
            OvalShape1.BackColor = Color.Red
            OvalShape2.BackColor = Color.Red
            OvalShape3.BackColor = Color.Red
            OvalShape4.BackColor = Color.Red
            Label9.Text = "0"
        ElseIf jam = 0 And menit = 5 And detik = 59 Then
            My.Computer.Audio.Play(My.Resources.bel1,
    AudioPlayMode.Background)
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label1.Hide()
        Label9.Show()
        dtk = 7
        OvalShape1.BackColor = Color.Red
        OvalShape2.BackColor = Color.Empty
        OvalShape3.BackColor = Color.Empty
        OvalShape4.BackColor = Color.Empty
        If change1 Then
            jam = TextBox1.Text
            menit = TextBox2.Text
            detik = TextBox3.Text
            Timer1.Enabled = True
        ElseIf change2 = True Then
            jam = TextBox6.Text
            menit = TextBox5.Text
            detik = TextBox4.Text
            Timer1.Enabled = True
        ElseIf change3 = True Then
            jam = TextBox9.Text
            menit = TextBox8.Text
            detik = TextBox7.Text
            Timer1.Enabled = False
            Label9.Hide()
            Label1.Show()
            Timer2.Enabled = True

            OvalShape1.BackColor = Color.Lime
            OvalShape2.BackColor = Color.Lime
            OvalShape3.BackColor = Color.Lime
            OvalShape4.BackColor = Color.Lime
        End If

        Label1.Text = Format(jam) & ":" & Format(menit) & ":" & Format(detik)
        Button1.Enabled = False
        Button1.BackColor = Color.MediumSeaGreen
        Button2.Enabled = True
        Button2.BackColor = Color.Red
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        Button2.Enabled = False
        Button2.BackColor = Color.Firebrick
        Button5.Enabled = True

        Button4.Enabled = True
        OvalShape1.BackColor = Color.Red
        OvalShape2.BackColor = Color.Red
        OvalShape3.BackColor = Color.Red
        OvalShape4.BackColor = Color.Red
        My.Computer.Audio.Stop()

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Button3.Text = "ATUR" Then
            Button3.Text = "SAVE"

            Button4.Enabled = True
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox1.Focus()

        ElseIf Button3.Text = "SAVE" Then
            If TextBox1.Text = "00" And TextBox2.Text = "00" And TextBox3.Text = "00" Then
                MsgBox("Waktu belum di atur", vbCritical, "Error Input")
                TextBox1.Focus()
            Else
                Button3.Text = "ATUR"
                Button4.Enabled = False
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
            End If
        End If

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Button3.Text = "ATUR"
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False

    End Sub


    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        GroupBox4.Hide()
        RadioButton1.Text = "RACE"
        ComboBox1.Top = "71"
        ComboBox2.Top = "71"
        ComboBox1.BackColor = Color.Empty
        ComboBox2.BackColor = Color.Empty
        ComboBox3.BackColor = Color.Empty
        ComboBox4.BackColor = Color.Empty

        ComboBox5.BackColor = Color.Empty
        ComboBox6.BackColor = Color.Empty
        ComboBox7.BackColor = Color.Empty
        ComboBox8.BackColor = Color.Empty
        Label2.Text = "START 1"
        Label3.Text = "START 2"
        Label4.Text = "START 3"
        Label5.Text = "START 4"

        Label11.Text = "START 1"
        Label11.Left = "38"
        Label14.Text = "START 4"
        Label14.Left = "760"
        Label12.Show()
        Label13.Show()
        Label2.ForeColor = Color.Yellow
        Label3.ForeColor = Color.Red
        Label4.ForeColor = Color.Blue
        Label5.ForeColor = Color.Green

        Label11.ForeColor = Color.Yellow
        Label12.ForeColor = Color.Red
        Label13.ForeColor = Color.Blue
        Label14.ForeColor = Color.Green

        ComboBox1.ForeColor = Color.Empty
        ComboBox2.ForeColor = Color.Empty
        ComboBox5.ForeColor = Color.Empty
        ComboBox7.ForeColor = Color.Empty

        ComboBox3.Show()
        ComboBox2.Show()
        ComboBox6.Show()
        ComboBox7.Show()
        Label4.Show()
        Label5.Show()
        Label12.Show()
        Label13.Show()
        ComboBox4.Location = New Point(18, 203)
        ComboBox1.Location = New Point(29, 75)
        ComboBox5.Location = New Point(6, 59)
        ComboBox8.Location = New Point(755, 58)

        ComboBox1.Size = New Point(329, 37)
        ComboBox4.Size = New Point(329, 37)
        Label2.Size = New Point(198, 40)
        Label3.Size = New Point(198, 40)

        Label2.Location = New Point(105, 16)
        Label3.Location = New Point(89, 16)

        Label11.Size = New Point(198, 40)
        Label14.Size = New Point(198, 40)

        Label11.Location = New Point(6, 10)
        Label14.Location = New Point(762, 10)

    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        GroupBox4.Hide()
        RadioButton1.Text = "BATTLE"
        Label11.Text = "TRACK MERAH"
        Label11.Left = "150"
        Label14.Text = "TRACK BIRU"
        Label14.Left = "650"
        Label12.Hide()
        Label13.Hide()
        ComboBox1.Top = "90"
        ComboBox2.Top = "90"
        ComboBox1.BackColor = Color.Red
        ComboBox2.BackColor = Color.Red
        ComboBox3.BackColor = Color.CornflowerBlue
        ComboBox4.BackColor = Color.CornflowerBlue

        ComboBox5.BackColor = Color.Red
        ComboBox6.BackColor = Color.CornflowerBlue
        ComboBox7.BackColor = Color.Red
        ComboBox8.BackColor = Color.CornflowerBlue
        Label2.Text = "TRACK MERAH"
        Label3.Text = "TRACK BIRU"
        Label4.Text = "VS"
        Label5.Text = "VS"
        Label2.ForeColor = Color.White
        Label3.ForeColor = Color.White
        Label4.ForeColor = Color.White
        Label5.ForeColor = Color.white
        Label11.ForeColor = Color.White
        Label12.ForeColor = Color.White
        Label13.ForeColor = Color.White
        Label14.ForeColor = Color.White

        ComboBox1.ForeColor = Color.White
        ComboBox2.ForeColor = Color.White
        ComboBox5.ForeColor = Color.White
        ComboBox7.ForeColor = Color.White


        ComboBox3.Hide()
        ComboBox2.Hide()
        ComboBox6.Hide()
        ComboBox7.Hide()
        Label5.Hide()
        Label4.Hide()
        Label12.Hide()
        Label13.Hide()
        ComboBox4.Location = New Point(18, 130)
        ComboBox1.Location = New Point(29, 130)
        ComboBox5.Location = New Point(140, 58)
        ComboBox8.Location = New Point(640, 58)

        Label2.Size = New Point(270, 37)
        Label3.Size = New Point(270, 37)

        Label2.Location = New Point(50, 56)
        Label3.Location = New Point(50, 56)


        Label11.Size = New Point(270, 40)
        Label14.Size = New Point(270, 40)

        Label11.Location = New Point(106, 10)
        Label14.Location = New Point(610, 10)


    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Label1.Text = "00:00:00"
        Label9.Text = "0"
        OvalShape1.BackColor = Color.Maroon
        OvalShape2.BackColor = Color.DarkOrange
        OvalShape3.BackColor = Color.Olive
        OvalShape4.BackColor = Color.Green
        Button1.Enabled = True
        Button1.BackColor = Color.Lime
        Button5.Enabled = False
        Label9.Hide()
        Label1.Show()
       
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If Button6.Text = "SET TIMER" Then
            Button6.Text = "SET"
            GroupBox10.Show()
            GroupBox11.Show()
            GroupBox3.Show()
            GroupBox4.Hide()
            GroupBox6.Hide()
            GroupBox7.Hide()
            GroupBox2.Hide()
        ElseIf Button6.Text = "SET" Then
            Button6.Text = "SET TIMER"
            GroupBox10.Hide()
            GroupBox11.Hide()
            GroupBox3.Hide()
            GroupBox6.Show()
            GroupBox7.Show()
            GroupBox2.Show()
        End If

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        GroupBox4.Show()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        change1 = True
        Button1.Enabled = True
        Button1.BackColor = Color.Lime
        If RadioButton1.Text = "BATTLE" Then
            Label21.Text = "BATTLE"
        ElseIf RadioButton1.Text = "RACE" Then
            Label21.Text = "RACE"
        End If
    End Sub

    Private Sub RadioButton2_CheckedChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        RadioButton1.Checked = False
        change1 = False
        change2 = True
        Button1.Enabled = True
        Button1.BackColor = Color.Lime
        Label21.Text = "TRIAL"
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        RadioButton1.Checked = False
        change1 = False
        RadioButton2.Checked = False
        change2 = False
        change3 = True
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        Button1.Enabled = True
        Button1.BackColor = Color.Lime
        Label21.Text = "CALLING"
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If Button8.Text = "ATUR" Then
            Button8.Text = "SAVE"
            Button9.Enabled = True
            TextBox5.Enabled = True
            TextBox6.Enabled = True
            TextBox6.Focus()

        ElseIf Button8.Text = "SAVE" Then
            If TextBox4.Text = "00" And TextBox5.Text = "00" And TextBox6.Text = "00" Then
                MsgBox("Waktu belum di atur", vbCritical, "Error Input")
                TextBox6.Focus()
            Else
                Button8.Text = "ATUR"
                Button9.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox6.Enabled = False

            End If
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Button8.Text = "ATUR"
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If Button10.Text = "ATUR" Then
            Button10.Text = "SAVE"

            Button11.Enabled = True
            TextBox8.Enabled = True
            TextBox9.Enabled = True
            TextBox9.Focus()

        ElseIf Button10.Text = "SAVE" Then
            If TextBox7.Text = "00" And TextBox8.Text = "00" And TextBox9.Text = "00" Then
                MsgBox("Waktu belum di atur", vbCritical, "Error Input")
                TextBox6.Focus()
            Else
                Button10.Text = "ATUR"
                Button11.Enabled = False
                TextBox7.Enabled = False
                TextBox8.Enabled = False
                TextBox9.Enabled = False

            End If
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Button10.Text = "ATUR"
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        TextBox9.Enabled = False
    End Sub


    
  
    Private Sub pb_push_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_push.Click
        cb1 = ComboBox1.Text
        cb2 = ComboBox2.Text
        cb3 = ComboBox3.Text
        cb4 = ComboBox4.Text

        If RadioButton4.Checked Then
            ComboBox1.Text = ComboBox5.Text
            ComboBox2.Text = ComboBox6.Text
            ComboBox3.Text = ComboBox7.Text
            ComboBox4.Text = ComboBox8.Text

        ElseIf RadioButton5.Checked Then
            ComboBox1.Text = ComboBox5.Text
            ComboBox2.Text = ComboBox7.Text
            ComboBox3.Text = ComboBox6.Text
            ComboBox4.Text = ComboBox8.Text
        End If

    End Sub

    Private Sub bt_return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_return.Click
        ComboBox1.Text = cb1
        ComboBox2.Text = cb2
        ComboBox3.Text = cb3
        ComboBox4.Text = cb4
    End Sub


End Class
