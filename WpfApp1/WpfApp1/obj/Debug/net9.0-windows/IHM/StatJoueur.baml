   M S B A M L   `   `   `  ����C  ?Monopoly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Monopoly.IHMMonopoly.IHM  5   	       Monopoly.IHM.StatJoueur   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Monopoly.IHM     5   	     � Title$  
StatJoueur��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5       $��* �6   .+�5#   
   �� -   5         ��Name$ 	NomJoueur��5#      $�� ��6'   $��3��60   $��2��6@   $��1��6T   
�������$��Center=�6x   $��Center=�6�   �� 5&   
   -   5         ��Name$ NbPartieJouer��5&      $��Partie Jouer��6'   $��2��6>   $��2��6N   $��Center=�6[   $��Center=�6x   $
��Bold"�6�   �� 5'   
   -   5        $ NbPartieGagner��5'      $��Partie Gagner��6(   $��3��6@   $��2��6P   $��Center=�6]   $��Center=�6z   $
��Bold"�6�   �� 5(   
   -   5        $ NbPartiePerdu��5(      $��Partie Perdu��6'   $��4��6>   $��2��6N   $��Center=�6[   $��Center=�6x   $
��Bold"�6�   �� 5)   
   -   5        $ Ratio��5)      $��Ratio��6   $��5��6/   $��2��6?   $��Center=�6L   $��Center=�6i   $
��Bold"�6�   �� 5+   
   -   5        $ NbPartieJouerValue��5+      $��0��60   $��2��69   $��3��6I   $��Center=�6V   $��Center=�6s   �� 5,   
   -   5        $ NbPartieGagnerValue��5,      $��0��61   $��3��6:   $��3��6J   $��Center=�6W   $��Center=�6t   �� 5-   
   -   5        $ NbPartiePerduValue��5-      $��0��60   $��4��69   $��3��6I   $��Center=�6V   $��Center=�6s   �� 5.   
   -	   5        $ 
RatioValue��5.      $
��0.00��6(   $��5��64   $��3��6D   $��Center=�6Q   $��Center=�6n   �� 52   
   -
   5         ��Name$ ListeProprietes��52      $��1��6+   $��2��6;   $��5��6O   $��5��6\   $��10q�6m   
�������$��Stretch=�6�   $��Stretch=�6�   ��53      �� 54      .R�55      �� ��6    �� 56      58      �� 59   
   -   5        $ LabelStatSelect��59      $&��  Selectionner vos statistiques !��6)   $��4��6T   $��5��6d   $��3��6q   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   �� 5:   
   -   5         ��Name$ statImg��5:      $��4��6!   $��3��61   $��6��6E   $��4��6R   $��Stretch=�6c   $��Stretch=�6   5<      5=      