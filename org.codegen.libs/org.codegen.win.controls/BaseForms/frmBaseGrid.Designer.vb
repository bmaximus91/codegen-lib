<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBaseGrid
    Inherits frmBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    Sub New()


        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Font = FormsApplicationContext.current.ApplicationDefaultFont

    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBaseGrid))
        Me.mnActions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.cmdSelectAndClose = New System.Windows.Forms.ToolStripButton()
        Me.cmdSelectCancel = New System.Windows.Forms.ToolStripButton()
        Me.pnlEditToolbar = New System.Windows.Forms.Panel()
        Me.tlStripList = New System.Windows.Forms.ToolStrip()
        Me.cmdAdd = New System.Windows.Forms.ToolStripButton()
        Me.cmdEdit = New System.Windows.Forms.ToolStripButton()
        Me.cmdDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsepPrintAndExcel = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdPrint = New System.Windows.Forms.ToolStripButton()
        Me.cmdExcel = New System.Windows.Forms.ToolStripButton()
        Me.cmdConfigureGrid = New System.Windows.Forms.ToolStripButton()
        Me.tsepSearch = New System.Windows.Forms.ToolStripSeparator()
        Me.tsLblSearch = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsTxtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.tsReportButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnActions.SuspendLayout()
        Me.pnlEditToolbar.SuspendLayout()
        Me.tlStripList.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnActions
        '
        Me.mnActions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnAdd, Me.mnEdit, Me.mnDelete})
        Me.mnActions.Name = "mnActions"
        Me.mnActions.Size = New System.Drawing.Size(153, 92)
        '
        'mnAdd
        '
        Me.mnAdd.Name = "mnAdd"
        Me.mnAdd.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.mnAdd.Size = New System.Drawing.Size(152, 22)
        Me.mnAdd.Text = "Add"
        '
        'mnEdit
        '
        Me.mnEdit.Name = "mnEdit"
        Me.mnEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.mnEdit.Size = New System.Drawing.Size(152, 22)
        Me.mnEdit.Text = "Edit"
        '
        'mnDelete
        '
        Me.mnDelete.Name = "mnDelete"
        Me.mnDelete.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.mnDelete.Size = New System.Drawing.Size(152, 22)
        Me.mnDelete.Text = "Delete"
        '
        'pnlGrid
        '
        Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrid.Location = New System.Drawing.Point(0, 25)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(971, 329)
        Me.pnlGrid.TabIndex = 3
        '
        'cmdSelectAndClose
        '
        Me.cmdSelectAndClose.Image = CType(resources.GetObject("cmdSelectAndClose.Image"), System.Drawing.Image)
        Me.cmdSelectAndClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSelectAndClose.Name = "cmdSelectAndClose"
        Me.cmdSelectAndClose.Size = New System.Drawing.Size(115, 22)
        Me.cmdSelectAndClose.Text = "Select And Close"
        '
        'cmdSelectCancel
        '
        Me.cmdSelectCancel.Image = Global.org.codegen.win.controls.My.Resources.Resources.synch
        Me.cmdSelectCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSelectCancel.Name = "cmdSelectCancel"
        Me.cmdSelectCancel.Size = New System.Drawing.Size(63, 22)
        Me.cmdSelectCancel.Text = "Cancel"
        '
        'pnlEditToolbar
        '
        Me.pnlEditToolbar.Controls.Add(Me.tlStripList)
        Me.pnlEditToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEditToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlEditToolbar.Name = "pnlEditToolbar"
        Me.pnlEditToolbar.Size = New System.Drawing.Size(971, 25)
        Me.pnlEditToolbar.TabIndex = 0
        '
        'tlStripList
        '
        Me.tlStripList.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.tlStripList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlStripList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdSelectAndClose, Me.cmdSelectCancel, Me.cmdAdd, Me.cmdEdit, Me.cmdDelete, Me.tsepPrintAndExcel, Me.cmdPrint, Me.cmdExcel, Me.cmdConfigureGrid, Me.tsepSearch, Me.tsLblSearch, Me.tsTxtSearch, Me.tsReportButton})
        Me.tlStripList.Location = New System.Drawing.Point(0, 0)
        Me.tlStripList.Name = "tlStripList"
        Me.tlStripList.Size = New System.Drawing.Size(971, 25)
        Me.tlStripList.TabIndex = 3
        Me.tlStripList.Text = "tlStripList"
        '
        'cmdAdd
        '
        Me.cmdAdd.Image = Global.org.codegen.win.controls.My.Resources.Resources.AddTableHS
        Me.cmdAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(51, 22)
        Me.cmdAdd.Text = "New"
        '
        'cmdEdit
        '
        Me.cmdEdit.Image = Global.org.codegen.win.controls.My.Resources.Resources.EditTableHS
        Me.cmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(47, 22)
        Me.cmdEdit.Text = "Edit"
        '
        'cmdDelete
        '
        Me.cmdDelete.Image = Global.org.codegen.win.controls.My.Resources.Resources.DeleteHS
        Me.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(60, 22)
        Me.cmdDelete.Text = "Delete"
        '
        'tsepPrintAndExcel
        '
        Me.tsepPrintAndExcel.Name = "tsepPrintAndExcel"
        Me.tsepPrintAndExcel.Size = New System.Drawing.Size(6, 25)
        '
        'cmdPrint
        '
        Me.cmdPrint.Image = Global.org.codegen.win.controls.My.Resources.Resources.PrintHS
        Me.cmdPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(52, 22)
        Me.cmdPrint.Text = "Print"
        '
        'cmdExcel
        '
        Me.cmdExcel.Image = Global.org.codegen.win.controls.My.Resources.Resources.toExcel
        Me.cmdExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(70, 22)
        Me.cmdExcel.Text = "To Excel"
        '
        'cmdConfigureGrid
        '
        Me.cmdConfigureGrid.Image = Global.org.codegen.win.controls.My.Resources.Resources.synch
        Me.cmdConfigureGrid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdConfigureGrid.Name = "cmdConfigureGrid"
        Me.cmdConfigureGrid.Size = New System.Drawing.Size(118, 22)
        Me.cmdConfigureGrid.Text = "Choose Columns"
        '
        'tsepSearch
        '
        Me.tsepSearch.Name = "tsepSearch"
        Me.tsepSearch.Size = New System.Drawing.Size(6, 25)
        '
        'tsLblSearch
        '
        Me.tsLblSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsLblSearch.Name = "tsLblSearch"
        Me.tsLblSearch.Size = New System.Drawing.Size(58, 22)
        Me.tsLblSearch.Text = "Search:"
        '
        'tsTxtSearch
        '
        Me.tsTxtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tsTxtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.tsTxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsTxtSearch.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.tsTxtSearch.Name = "tsTxtSearch"
        Me.tsTxtSearch.Size = New System.Drawing.Size(116, 25)
        '
        'tsReportButton
        '
        Me.tsReportButton.Image = Global.org.codegen.win.controls.My.Resources.Resources.trends
        Me.tsReportButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReportButton.Name = "tsReportButton"
        Me.tsReportButton.Size = New System.Drawing.Size(76, 22)
        Me.tsReportButton.Text = "Reports"
        '
        'frmBaseGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(971, 354)
        Me.Controls.Add(Me.pnlGrid)
        Me.Controls.Add(Me.pnlEditToolbar)
        Me.MaximizeBox = True
        Me.MinimizeBox = True
        Me.Name = "frmBaseGrid"
        Me.Text = "frmBaseGrid"
        Me.mnActions.ResumeLayout(False)
        Me.pnlEditToolbar.ResumeLayout(False)
        Me.pnlEditToolbar.PerformLayout()
        Me.tlStripList.ResumeLayout(False)
        Me.tlStripList.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents mnActions As System.Windows.Forms.ContextMenuStrip
    Public WithEvents pnlGrid As System.Windows.Forms.Panel

    Public WithEvents tlStripList As System.Windows.Forms.ToolStrip
    Public WithEvents cmdAdd As System.Windows.Forms.ToolStripButton
    Public WithEvents cmdEdit As System.Windows.Forms.ToolStripButton
    Public WithEvents cmdDelete As System.Windows.Forms.ToolStripButton
    Public WithEvents tsepPrintAndExcel As System.Windows.Forms.ToolStripSeparator
    Public WithEvents cmdPrint As System.Windows.Forms.ToolStripButton
    Public WithEvents cmdExcel As System.Windows.Forms.ToolStripButton
    Public WithEvents cmdConfigureGrid As System.Windows.Forms.ToolStripButton
    Public WithEvents tsepSearch As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsLblSearch As System.Windows.Forms.ToolStripDropDownButton
	Public WithEvents tsTxtSearch As System.Windows.Forms.ToolStripTextBox
	Friend WithEvents pnlEditToolbar As System.Windows.Forms.Panel
    Public WithEvents cmdSelectAndClose As System.Windows.Forms.ToolStripButton
    Public WithEvents cmdSelectCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnAdd As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsReportButton As System.Windows.Forms.ToolStripDropDownButton



End Class
