   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   Folder Order   Folder_Order.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     9System&clr-namespace:System;assembly=mscorlib     -     �Name$  W_Main�� � Title$ Folder Order��$	��462��$	��532�� � 
ResizeMode$ NoResize=� � Icon$ Resources/icon.png������  �� ImageSource$ Resources/background.jpg�� j� Stretch$ UniformToFill=�.���  J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Opacity$
 0.25Q�   RenderingBias$ Quality=�	   
BlurRadius$	 15Q�.+�	� -   
 	�Name$
 R_List��$��Scegli dalla lista��$
��Left=�$��
11,277,0,0q�$	��Top=� d� 	IsChecked$
 TrueY�
�������	� -   $
 R_Text��$��Aggiungi nuovo��$
��Left=�$��
11,313,0,0q�$	��Top=�
��������� -    ��Name$ C_List��$
��Left=�$��135,274,0,0q�$	��Top=�$	��256��{��� *	IsChecked+ �� ElementName$ R_List���� -    ��Name$ T_FolderName��$
��Left=�$��23��$��135,311,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��256�� �� 	IsEnabled . {��� *	IsChecked+$ R_Text���� -    ��Name$ B_Start��$��Start��$
��Left=�$��
11,352,0,0q�$	��Top=�$��75��� -    �Name$ PB_Progress��$
��Left=�$��22��$��
11,387,0,0q�$	��Top=�$	��497�����	#FF0672B0 � Minimum$ 1Q� � Value$ 0Q��� -    ��Name$ L_Status��$��In attesa...��$
��Left=�$��
91,349,0,0q�$	��Top=�$	��417��
��������� -	   $
 B_Ok��$��Conferma��$
��Left=�$��431,275,0,0q�$	��Top=�$��75���� -
    ��Name$ 
LV_Folders��$
��Left=�$	��229��$��	10,10,0,0q�$	��Top=�$	��497�� J� Opacity$	 0.8Q� �� View �� .P��� $��Nome cartella origine�� �� Width$	 250�� �� DisplayMemberBinding �� *opath+�� $ ��Nome cartella destinazione��$	 200�� �� *dpath+ � ContextMenu �� .@�m� -   $��menuItem_Property��$��Proprietà cartella��m� -   $��menuItem_Remove��$��Rimuovi da elenco���� -   $ B_Cancel��$��Annulla��$
��Left=�$��431,313,0,0q�$	��Top=�$��75���� -   $ L_Info��$I��CNota: Fare click destro su un elemento della lista apre le opzioni.��$
��Left=�$��
11,239,0,0q�$	��Top=�$	��417��
�������      ShadowDepth$ 0Q�