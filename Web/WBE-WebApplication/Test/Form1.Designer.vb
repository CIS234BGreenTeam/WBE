<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstGood = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstError = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstErrorGood = New System.Windows.Forms.ListBox()
        Me.lstGoodError = New System.Windows.Forms.ListBox()
        Me.btnTestBakedGood = New System.Windows.Forms.Button()
        Me.btnTestSchedule = New System.Windows.Forms.Button()
        Me.btnTestOrderItems = New System.Windows.Forms.Button()
        Me.btnTestOrders = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lstGood
        '
        Me.lstGood.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGood.ItemHeight = 14
        Me.lstGood.Location = New System.Drawing.Point(12, 23)
        Me.lstGood.Name = "lstGood"
        Me.lstGood.Size = New System.Drawing.Size(712, 74)
        Me.lstGood.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Expected good - have good"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Expected error - have error"
        '
        'lstError
        '
        Me.lstError.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstError.ItemHeight = 14
        Me.lstError.Location = New System.Drawing.Point(12, 135)
        Me.lstError.Name = "lstError"
        Me.lstError.Size = New System.Drawing.Size(712, 74)
        Me.lstError.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 225)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Expected good - have error"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 346)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Expected error - have good"
        '
        'lstErrorGood
        '
        Me.lstErrorGood.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstErrorGood.ItemHeight = 14
        Me.lstErrorGood.Location = New System.Drawing.Point(12, 362)
        Me.lstErrorGood.Name = "lstErrorGood"
        Me.lstErrorGood.Size = New System.Drawing.Size(712, 74)
        Me.lstErrorGood.TabIndex = 13
        '
        'lstGoodError
        '
        Me.lstGoodError.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGoodError.ItemHeight = 14
        Me.lstGoodError.Location = New System.Drawing.Point(12, 241)
        Me.lstGoodError.Name = "lstGoodError"
        Me.lstGoodError.Size = New System.Drawing.Size(712, 74)
        Me.lstGoodError.TabIndex = 12
        '
        'btnTestBakedGood
        '
        Me.btnTestBakedGood.Location = New System.Drawing.Point(444, 463)
        Me.btnTestBakedGood.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTestBakedGood.Name = "btnTestBakedGood"
        Me.btnTestBakedGood.Size = New System.Drawing.Size(105, 24)
        Me.btnTestBakedGood.TabIndex = 33
        Me.btnTestBakedGood.Text = "Test Baked Good"
        Me.btnTestBakedGood.UseVisualStyleBackColor = True
        '
        'btnTestSchedule
        '
        Me.btnTestSchedule.Location = New System.Drawing.Point(15, 459)
        Me.btnTestSchedule.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTestSchedule.Name = "btnTestSchedule"
        Me.btnTestSchedule.Size = New System.Drawing.Size(83, 24)
        Me.btnTestSchedule.TabIndex = 32
        Me.btnTestSchedule.Text = "Test Schedule"
        Me.btnTestSchedule.UseVisualStyleBackColor = True
        '
        'btnTestOrderItems
        '
        Me.btnTestOrderItems.Location = New System.Drawing.Point(309, 463)
        Me.btnTestOrderItems.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTestOrderItems.Name = "btnTestOrderItems"
        Me.btnTestOrderItems.Size = New System.Drawing.Size(104, 24)
        Me.btnTestOrderItems.TabIndex = 31
        Me.btnTestOrderItems.Text = "Test Orderitem"
        Me.btnTestOrderItems.UseVisualStyleBackColor = True
        '
        'btnTestOrders
        '
        Me.btnTestOrders.Location = New System.Drawing.Point(195, 463)
        Me.btnTestOrders.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTestOrders.Name = "btnTestOrders"
        Me.btnTestOrders.Size = New System.Drawing.Size(83, 24)
        Me.btnTestOrders.TabIndex = 30
        Me.btnTestOrders.Text = "Test Orders"
        Me.btnTestOrders.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DarkRed
        Me.Label5.Location = New System.Drawing.Point(221, 225)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(283, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Investigate any thing that appears in the bottom 2 listboxes"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 494)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnTestBakedGood)
        Me.Controls.Add(Me.btnTestSchedule)
        Me.Controls.Add(Me.btnTestOrderItems)
        Me.Controls.Add(Me.btnTestOrders)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lstErrorGood)
        Me.Controls.Add(Me.lstGoodError)
        Me.Controls.Add(Me.lstError)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstGood)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstGood As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstError As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstErrorGood As System.Windows.Forms.ListBox
    Friend WithEvents lstGoodError As System.Windows.Forms.ListBox
    Friend WithEvents btnTestBakedGood As System.Windows.Forms.Button
    Friend WithEvents btnTestSchedule As System.Windows.Forms.Button
    Friend WithEvents btnTestOrderItems As System.Windows.Forms.Button
    Friend WithEvents btnTestOrders As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
