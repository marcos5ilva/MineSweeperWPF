   M S B A M L   `   `   `  ����I  EMineSweeperWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MineSweeperWPFMineSweeperWPF  5   	       MineSweeperWPF.GameWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MineSweeperWPF     5   	     � Title$  
GameWindow��5   	   $	��640��6   $	��360��6)    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � -   5         �Name$ gameGrid��5
      ���	#FF0098CA � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��80 �6   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $��80 �6   .+�5   
   �� -   5         ��Name$ image2��5      $��center=�6    $	��400��6=   $��3��6J   $T��NC:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\radarBackground.png��6W   $��Center=�6�   $	��300��6�   � 5   
   -   5        $ cellGrid��5      $��3��6!   $
��auto��6/   $
��auto��6<   $��Center=�6J   $��Center=�6g    K� ZIndex$ 7��6�   5      �� 5   
   -   5        $ NumberOfMinesImg��5      $V��PC:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\mineCounterPannel.png��6*   $
��Left=�6�   $	��105��6�   $��1��6�   $��3��6�   $	��Top=�6�   $	��140��6�   $��10,0,0,0q�6�   �� 5   
   -   5         ��Name$ NumberOfMines��5      $��0��6'   $
��Left=�63   $��	59,15,0,0q�6N   $��1��6a   $	��Top=�6n   $��52��6�   $��71��6�   $��	ExtraBold"�6�   $��35(�6�   $��Stencil)�6�   
�������6�   �� 5   
   -   5        $ GameTimerImg��5      $V��PC:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\timeCounterPannel.png��6&   $
��Left=�6�   $	��104��6�   $��	189,0,0,0q�6�   $��1��6�   $��2��6�   $	��Top=�6�   $	��140��6�   �� 5   
   -   5        $ 	GameTimer��5      $��0��6#   $
��Left=�6/   $��
244,15,0,0q�6J   $��1��6^   $	��Top=�6k   $��46��6�   $��70��6�   $��	ExtraBold"�6�   $��35(�6�   $��Stencil)�6�   
�������6�   �� 5   
   -   5        $ image3��5      $��Center=�6    $	��103��6=   $V��PC:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\stopCounterPannel.png��6J   $��4��6�   $��Center=�6�   $	��268��6�   $��3��6�   �� 5    
   -	   5         ��Name$ 
StopButton��5       $
��STOP��6%   $��Center=�64   $��4��6R   $��Center=�6_   $��75��6z   $��2��6�   $��38��6�   ���	#FFE62E2E$��Stencil)�6�   $��18(�6�   ��6�   Z� 6�   �� 5!   
   -
   5        $ GameOverLogo��5!      $Q��KC:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\gameOverLogo.png��6&   $	��125��6{   $��	26,1,38,0q�6�   $	��Top=�6�   $��4��6�   $ 10��6�   �� 5"   
   -   5        $ 
TimerLabel��5"      $��Time: ��6$   $
��Left=�65   $��
123,10,0,0q�6P   $��3��6d   $	��Top=�6q   
�������$��Stencil)�6�   $��24(�6�   ��6�   Z� 6�   �� 5#   
   -   5        $ 	TimeScore��5#      $��0��6#   $
��Left=�6/   $��
205,10,0,0q�6J   $��3��6^   $	��Top=�6k   
�������$��Stencil)�6�   $��24(�6�   ��6�   Z� 6�   �� 5$   
   -   5        $ 
WinMsgLogo��5$      $	��125��6$   $��	26,1,38,0q�61   $	��Top=�6D   $��4��6\   $O��IC:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\WinMsgLogo.png��6m   $ 10��6�   5%      5&      