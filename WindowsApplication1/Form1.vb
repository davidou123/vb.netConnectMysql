Imports MySql.Data.MySqlClient


Public Class Form1
    Public KDBconn As New MySqlConnection
    Public KDBconnBackUp As New MySqlConnection
    Public KDBconnLib As New MySqlConnection
    Public Sub GetKDBConn()
        Dim connString As String = "Database=test;Data Source=127.0.0.1;User Id=root;Password=0000;CharSet=utf8"
        Dim tmpSql As String
        If KDBconn.State = ConnectionState.Open Then KDBconn.Close() '若第二次重複連線需關閉
        KDBconn = New MySqlConnection(connString)
        KDBconn.Open()

        If KDBconn Is Nothing Then
            If connString = "" Then
                MsgBox("未設定連線字串" & connString)
            Else
                KDBconn = New MySqlConnection(connString)
                KDBconn.Open() '"正常連結資料庫"
                MsgBox("ok")
            End If
        Else
        End If
        If KDBconn Is Nothing Then MsgBox("MYSQL資料庫連線失敗")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SQL_Statement As String
        Dim cmd As MySqlCommand
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        GetKDBConn()
        Dim str1 As String = "select * from country"

        Dim adp1 As MySqlDataAdapter = New MySqlDataAdapter(str1, KDBconn)

        '將查詢結果放到記憶體set1上的"1a "表格內

        Dim set1 As DataSet = New DataSet

        adp1.Fill(set1, "1a")

        '將記憶體的資料集合存放到視窗畫面上的DataGrid上

        DataGridView1.DataSource = set1.Tables("1a")

        '關閉資料庫的連結

        KDBconn.Close()

    End Sub
End Class
