Imports System.Runtime.InteropServices

<ComVisible(true)> _ 
Public Class TransferControl

	Private Shared _Answers As New Collections.Generic.List(Of String)()
	Private Shared _ImagesList As New Collections.Generic.Dictionary(Of String, String)()
	Private Shared _Images As New Collections.Generic.SortedDictionary(Of String, Image)
	Private Shared file As PTK.File.PTKFile
	
	Public Event Finished()
	
	Public ReadOnly Property Answers As Collections.Generic.List(Of String)	
		Get
			Return _Answers
		End Get		
	End Property
	
	Public ReadOnly Property ImagesLinks As Collections.Generic.Dictionary(Of String, String)
		Get
			Return _ImagesList			
		End Get		
	End Property
	
	Public ReadOnly Property Images As Collections.Generic.SortedDictionary(Of String, Image)
		Get
			Return _Images		
		End Get		
	End Property
	
	Public Sub AddAnswer(Text As String) 
		Answers.Add(text)		
	End Sub
	
	Public Sub AddImage(Text As String, File As String) 				
		ImagesLinks.Add(text, file)		
	End Sub
	
	Public Sub AddImage(Text As String, File As Image) 				
		Images.Add(Text, File)
	End Sub
	
	Public Sub ClearThemAll()
		Answers.Clear()
		ImagesLinks.Clear()
		Images.Clear()
	End Sub
	
	Public Sub Begin(byref f2 as PTK.File.PTKFile)
		Me.ClearThemAll()
		file = f2
	End Sub
	
	Public Sub Finish()		
		For Each Answer As String In Me.Answers
			file.OtherAnswersItems.Add(Answer)
		Next
		For Each Answer As String In Me.ImagesLinks.Keys
			file.ImageAnswersItems.Add(answer, Me.Images.Item(Me.ImagesLinks.Item(answer)))
		Next
		RaiseEvent Finished()
	End Sub
	
	Public Shared ReadOnly Property Instance As TransferControl
		Get
			Dim tc as New TransferControl()
			Return tc			
		End Get
	End Property
	
End Class
