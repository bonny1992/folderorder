   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    Folder Order   Folder_Order.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   -   5          �Name$  W_Main��5   ?    � Title$ Folder Order��5   	   $	��436��6   $	��532��6+    � 
ResizeMode$ NoResize=�67    � Icon$ Resources/icon.png��6M   ��5      �� 5   
    �� ImageSource$ Resources/background.jpg��6    j� Stretch$ UniformToFill=�6<   .��5	      �  J� Effect 5
   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Opacity$
 0.25Q�6      RenderingBias$ Quality=�6.   	   
BlurRadius$	 15Q�6F   .+�5   
   	� -   5        
 	�Name$
 R_List��5      $��Scegli dalla lista��6&   $
��Left=�6C   $��
10,254,0,0q�6^   $	��Top=�6r    d� 	IsChecked$
 TrueY�6�   
�������6�   	� 5   
   -   5        $
 R_Text��5      $��Aggiungi nuovo��6&   $
��Left=�6?   $��
10,290,0,0q�6Z   $	��Top=�6n   
�������6�   �� 5   
   -   5         ��Name$ C_List��5      $
��Left=�6#   $��134,251,0,0q�6>   $	��Top=�6S   $	��256��6k   {�6w   �� *	IsChecked+ �� ElementName$ R_List���� 5   
   -   5         ��Name$ T_FolderName��5      $
��Left=�6(   $��23��6C   $��134,288,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��256��6�    �� 	IsEnabled . {�6�   �� *	IsChecked+$ R_Text���� 5   
   -   5         ��Name$ B_Start��5      $��Start��6"   $
��Left=�62   $��
10,329,0,0q�6M   $	��Top=�6a   $��75��6y   6�   � 5   
   -   5         �Name$ PB_Progress��5      $
��Left=�6+   $��22��6F   $��
10,364,0,0q�6R   $	��Top=�6f   $	��497��6~   ���	#FF0672B0 � Minimum$ 1Q�6�    � Value$ 0Q�6�   �� 5   
   -   5         ��Name$ L_Status��5      $��In attesa...��6"   $
��Left=�69   $��
90,326,0,0q�6T   $	��Top=�6h   $	��417��6�   
�������6�   �� 5   
   -	   5        $
 B_Ok��5      $��Conferma��6   $
��Left=�62   $��430,252,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 5   
   -
   5         ��Name$ 
LV_Folders��5      $
��Left=�6'   $	��229��6B   $��	10,10,0,0q�6O   $	��Top=�6b   $	��497��6z    J� Opacity$	 0.8Q�6�    �� View 5      �� 5      .P�5      �� $��Nome cartella origine��6%    �� Width$	 250��6D    �� DisplayMemberBinding 6P   �� *opath+�� 5      $ ��Nome cartella destinazione��6%   $	 200��6I    6U   �� *dpath+5      5      �� 5   
   -   5        $ B_Cancel��5      $��Annulla��6#   $
��Left=�65   $��430,290,0,0q�6P   $	��Top=�6e   $��75��6}   6�   5      5      