   M S B A M L   `   `   `  ����R  NGuild Wars 2 AutoTrader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Guild_Wars_2_AutoTrader.User_Control$Guild_Wars_2_AutoTrader.User_Control  5      8    2Guild_Wars_2_AutoTrader.User_Control.ScriptOptions   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:Guild_Wars_2_AutoTrader.User_Control     5      
�������  � 	Resources  5       �� 
TargetType   ACheckedBox �� Property �� Value  GrayedOutCheckedBox��%�   &	        &	 U     �� 5   
   " ��6   .�5      ��  �@d�	IsChecked$ FalseY�6*   5      �� 5   
   " ��6   .�5      ��  �@d�	IsChecked$ FalseY�6*   �� 5       � {� .  6*   5      5      .��5      � -   5         �Name$ OptionsGrid��5       � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��75 �6    � ColumnDefinitions 5    
   �� 5!      $	��300 �6   �� 5"      $��30 �6   �� 5#      $��30 �6   �� 5$      $��* �6   .+�5'   
   �� -   5         ��Name$ Options��5'      $��Script Options��5(      $��20(�5)      $��Black"�5*       �� TextAlignment$ Right=�5+      $��Center=�5,      $��Center=�5-      	 �� Padding$	 0,7,0,0q�5.      $
��Wrap=�5/      $��0��50      $��4��51      $��0��52      �� 54   
   $��1��6   $��3��6%   $��1��69   $��5��6F   .+�55      �� -   5        
 ��Name$
 RemoveAllOrdersCb��55      $��Remove All Buy Orders��62   $
��Left=�56      $	��Top=�57      #��[  5:      $	��2.5q�5;       d� 	IsChecked 59      ��  �� Path$ CanRemoveAll�5;      �� 5>      -   5        $
 BuyAndSellCb��5>      $��Buy and Sell��6-   $
��Left=�5?      $	��Top=�5@      #��[  5B      $	��2.5q�5C       5A      �� $ CanBuyAndSell�5C      �� 5G      -   5        $
 BuyWeaponsCb��5G      $��Buy Weapons��6-   $
��Left=�5H      $	��Top=�5I      #��[ 5K      $��25,2.5,2.5,2.5q�5L       5J      �� $ CanBuyWeapon�5L      �� 5N      -   5        $
 RemoveBuyOrdersCb��5N      $��Remove Buy Orders��62   $
��Left=�5O      $	��Top=�5P      #��[ 5R      $��50,2.5,2.5,2.5q�5S       5Q      �� $ CanRemoveOrder�5S      �� 5U      -   5        $
 SellWeaponsCb��5U      $��Sell Weapons��6.   $
��Left=�5V      $	��Top=�5W      #��[ 5Y      $��25,2.5,2.5,2.5q�5Z       5X      �� $ CanSellWeapon�5Z      5\      �� 5_   
   -   5        $ IndexTb��5_      $ Right=�5`      $��Right=�5a      $	��Top=�5b      $	 0,7,0,0q�5c      $
��Wrap=�5d      $��Index: 1��6(   $��0��5e      $��7��5f      �� 5h   
   -	   5         ��Name$ GenerateScriptBtn��5h      $��Generate Script��6,   $��30��5i   1   $	��100��6=   $��Center=�5j      $	��Top=�5k      $��0��5l      $��7��5m      $��4��5n      5p      5q      