   M S B A M L   `   `   `  ����C  ?Monopoly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466J6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPFFontAwesome.WPF 5   	       WpfApp1.IHM.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   Efa6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPF     5   	     � Title$  
MainWindow��5	   	   $��382.5��6   $	��850��6+   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Image/Fond_Accueil.jpg��6   $
��Fill=�61    J� Opacity$ 1Q�6@    K� ZIndex$ 0��6L   $��3��6]   $��4��6q   �� 5   
   $��Monopoly F1��6   $��Center=�6'   $��Center=�6D   $��50(�6_   $��3��6m   
���   �6�   �� 5   
   -   5        $��Jouer��5      $��Center=�6!   $��Center=�6>   $��25(�6Y   $��1��6g   $��1��6t   $	��150��6�   $��50��6�   6�   �� 5   
   -   5        $��Login��5      $��Center=�6!   $��Center=�6>   $��25(�6Y   $��2��6g   $��1��6t   $	��150��6�   $��50��6�   6�   �� 5   
   -   5        $��Quitter��5      $��Center=�6#   $��Center=�6@   $��25(�6[   $��3��6i   $��1��6v   $	��150��6�   $��50��6�   6�   �� 5   
   -   5         ��Name$ state��5      $��2��6#   $
��Left=�63   $��30��6N   $��
185,10,0,0q�6Z   $
��Wrap=�6n   $��Serveur Off��6�   
���  ��$	��Top=�6�   $��72��6�   �� 5!   
   -   5         ��Name$ User1��5!      $��Invite��6   $��1��60   $��Center=�6=   $	��Top=�6Z   
�������6r   �� 5"   
   -   5        ���	#00FFFFFF$��1��5"   (   $��Center=�6F   $��center=�6c   ���	#00FFFFFF.��5#      "  FontAwesome.WPF.ImageAwesome  -   5          Name$ icon1��5#         Icon$ 
UserCircle=�6-   $��50��6?   $��Center=�6J   	   
Foreground
	 �����6z   5$      �� 5&   
   -   5        $ User2��5&      $��Invite��6   $��2��60   $��Center=�6=   $	��Top=�6Z   
�������6r   �� 5'   
   -	   5        ���	#00FFFFFF$��2��5'   (   $��Center=�6F   $��center=�6c   ���	#00FFFFFF.��5(        -
   5        $ icon2��5(      $ 
UserCircle=�6-   $��50��6?   $��Center=�6J   
	 �����6g   5)      5*      5+      