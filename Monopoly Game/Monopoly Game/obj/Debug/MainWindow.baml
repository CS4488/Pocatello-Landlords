   M S B A M L   `   `   `  ����H  DMonopoly Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Monopoly_GameMonopoly_Game  5   	       Monopoly_Game.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Monopoly_Game     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowState$ 	Maximized=�65   .��5	      � -   5         �Name$ mainGrid��5	      .+�5
   
   o� -   5        $��
mnMainMenu��5
      $��Stretch=�6!   $	��Top=�6?   $��20��6W   $��2��6c   .@�5      m� -   5        $��miGame��5      $
��Game��6%   .@�5      m� -   5        $��	miNewGame��5      $��New Game��6,   6>   m� 5      -   5        $��miExit��5      $
��Exit��6)   67   5      5       � 5   
   -   5          �Name$ frm_Main��5      $��Center=�6"   $��Center=�6F   � 5   
   -   5        $ InputBox��5      $y�	Collapsed=�6!   .+�5      � 
���   � J� Opacity$	 0.5Q�6&   �� 5      $	��250��5      
��� ���
���   �$��1q�5       �� CornerRadius$ 	0,55,0,55��5      $��Center=�5      $��Center=�5      ._�5      �� .+�5      �� $��5q�6    $)��#Please enter the number of players:��6+   $
��Bold"�6V   $��Cambria)�6h   �� 5      -   5         ��Name$ InputTextBox��5   e   $	��150��6   $��Center=�6-   $��Center=�6J   6e   �� 5       �� Orientation$ 
Horizontal=�6!   $��Center=�6:   .+�5       �� -	   5         ��Name$ ContinueButton��5    !   $��5q�69   $��Continue��6D   	 �� 	IsDefault	 . ��6W   Z� 6�   �� 5!      -
   5        $ CancelButton��5!   !   $��5q�67   $��Cancel��6B   
 �� IsCancel
 . ��6S   Z� 6�   5"      5#      5$      5%      5(      5)      