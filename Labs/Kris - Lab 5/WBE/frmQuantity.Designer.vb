<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuantity
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.lblBakedGood = New System.Windows.Forms.Label()
        Me.epQuantity = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.epQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Quantity"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(83, 44)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(57, 20)
        Me.txtQuantity.TabIndex = 1
        '
        'lblBakedGood
        '
        Me.lblBakedGood.AutoSize = True
        Me.lblBakedGood.Location = New System.Drawing.Point(66, 18)
        Me.lblBakedGood.Name = "lblBakedGood"
        Me.lblBakedGood.Size = New System.Drawing.Size(64, 13)
        Me.lblBakedGood.TabIndex = 2
        Me.lblBakedGood.Text = "BakedGood"
        '
        'epQuantity
        '
        Me.epQuantity.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.epQuantity.ContainerControl = Me
        '
        'frmQuantity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(203, 98)
        Me.Controls.Add(Me.lblBakedGood)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmQuantity"
        Me.Text = "Desired Quantity"
        CType(Me.epQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblBakedGood As System.Windows.Forms.Label
    Friend WithEvents epQuantity As System.Windows.Forms.ErrorProvider
End Class
