   M S B A M L   `   `   `  ����C  ?Monopoly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466J6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPFFontAwesome.WPF 5   	       WpfApp1.IHM.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   Efa6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPF     5   	     � Title$  
MainWindow��5	   	    � WindowStyle$
 None=�5
   	    � WindowState$ 	Maximized=�5   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5         GlassButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color	   Opacity
   
BlurRadius   ShadowDepth �� 
TargetType ��Name �� CornerRadius J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName��%  &	        �� 5   
   " ��6)   .�5      ��  � �� �	#66FFFFFF6+   �� 5       � ��
 �   �6+   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$ 22(�6)   �� 5       � ��$	 1.5q�60   �� 5       � �� �	#CCFFFFFF6,   �� 5       � ��$
 10,5q�6(   �� 5       �@�Cursor$
 Hand��6'   �� 5       �@J�Effect 5        5      $ Black��6'   $
	 0.15Q�65   $
 10Q�6D   $ 2Q�6T   5      �� 5       � �� 5       �� 5!      " ��6&   .R�5"      �� $ border��6!   #��z��5#      #��z��5$      #��z��5%      $ 8��5&      $
 True��5'      ._�5(      �� $��Center=�6/   $��Center=�6L   5)       5*      P� 5+       �@J�IsMouseOver$
 True��6=   . �5,   "   �� $ border��6)    � �� �	#99FFFFFF6S   �� 5-   "   $ border��6)    � ��
 �����6T   �� 5.   "   $ border��6)    �@J�Effect 5/   &     50   *   $ Black��6;   $		 0.4Q�6I   $
 15Q�6W   $ 3Q�6g   52   #   53      P� 54       � ��$
 True��6;   . �55   "   �� $ border��6)    � �� �	#CCFFFFFF6S   �� 56   "   $ border��6)    6O   Z�  �@J�Effect57      P� 58       � {�$ False��6;   . �59   "   ��  � �� �	#660000006?   �� 5:   "   $ border��6)    � �� �	#33FFFFFF6S   �� 5;   "   $ border��6)    � �� �	#33FFFFFF6T   �� 5<   "   $ border��6)    6O   Z�  �@J�Effect5=      5?      5A      5B      5C      .��5E      �  � RowDefinitions 5F   
   �� 5G      $��* �6   �� 5H      $��* �6   �� 5I      $��* �6   �� 5J      $��* �6    � ColumnDefinitions 5L   
   �� 5M      $��* �6   �� 5N      $��* �6   �� 5O      $��* �6   .+�5Q   
   �� $��Image/Fond_Accueil.jpg��6   $
��Fill=�61    J� Opacity$ 1Q�6@    K� ZIndex$ 0��6L   $��3��6]   $��4��6q   �� 5T   
   $��Monopoly F1��6   $��Center=�6'   $��Center=�6D   $��50(�6_   $��3��6m   
���   �6�   �� 5U   
   -   5        $��Jouer��5U      $��1��6!   $��1��6.   $	��150��6>   $��50��6J   #��[  6j   �� 5V   
   -   5        $��Login��5V      $��2��6!   $��1��6.   $	��150��6>   $��50��6J   #��[  6h   �� 5W   
   -   5        $��Quitter��5W      $��3��6#   $��1��60   $	��150��6@   $��50��6L   #��[  6e   �� 5Z   
   -   5         ��Name$ state��5Z      $��2��6#   $
��Left=�63   $��30��6N   $��
185,10,0,0q�6Z   $
��Wrap=�6n   $��Serveur Off��6�   
���  ��$	��Top=�6�   $��72��6�   �� 5]   
   -   5         ��Name$ User1��5]      $��Invite��6   $��1��60   $��Center=�6=   
�������$��3��6m   $��0,40,0,0q�6~   �� 5^   
   -   5        ���	#00FFFFFF$��1��5^   (   $��Center=�6F   $��center=�6c   ���	#00FFFFFF.��5_      "  FontAwesome.WPF.ImageAwesome  -   5          Name$ icon1��5_         Icon$ 
UserCircle=�6-   $��50��6?   $��Center=�6J      
Foreground
 �����6z   5`      �� 5b   
   -   5        $ User2��5b      $��Invite��6   $��2��60   $��Center=�6=   
�������$��2��6n   $��0,40,0,0q�6   �� 5c   
   -	   5        ���	#00FFFFFF$��2��5c   (   $��Center=�6F   $��center=�6c   ���	#00FFFFFF.��5d        -
   5        $ icon2��5d      $ 
UserCircle=�6-   $��50��6?   $��Center=�6J   
 �����6g   5e      �� 5g   
   -   5         ��Name$ 
VideoIntro��5g      $��0��5h   	   $��0��6   $��3��5i   	   $��4��6   $��Stretch=�5j   	   $��Stretch=�5k   	   $	 100��5l   	   .+�5m      r� -   5        $��
videoIntro��5m       r� Source$ IHM/Video/intro.mp4?�5n       r� LoadedBehavior$
 Play=�5o        r� UnloadedBehavior$
  Stop=�5p      ! r� Stretch$
! Fill=�5q      ��5r      �� *ActualWidth+" �� RelativeSource" �� # �� AncestorType
# Canvas��5s      �� *ActualHeight+" �� 
# Canvas5t      �� 5u      -   5        $
��skip��5u      $��90��6$   $��23��6/   #��[  6M   $
��Left=�6w   $��Center=�6�   $��15(�6�   
$ �� Top$$ 10��6�   % �� Left$% 10��6�   5v      5z      5{      