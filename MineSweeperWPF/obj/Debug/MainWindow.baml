   M S B A M L   `   `   `  ����I  EMineSweeperWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MineSweeperWPFMineSweeperWPF  5   	       MineSweeperWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MineSweeperWPF     5   	     � Title$  
MainWindow��5   	   $	��640��6   $	��360��6)    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $	��100 �6   �� 5      $	��400 �6   �� 5      $
��auto �6   �� 5      $	��400 �6   .+�5   
   �� -   5         ��Name$ image��5      $��center=�6   $	��670��6<   $��center=�6J   $	��830��6e   $M��GC:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\GameLogo.png��6q   $��5��6�   $��-239,-26,-239,337q�6�   �� 5   
   -   5         ��Name$ Normal��5      $��Normal��6!   $��Center=�62   $��Bottom=�6P   $	��196��6k   $��41��6w   $��2��6�   ���	#FF000131���	#FF007399$��Stencil)�6�   $��20(�6�   $��78,0,78,109q�6�   �� 5   
   -   5        $
 Easy��5      $
��Easy��6   $��Center=�6.   $��Bottom=�6L   $	��196��6g   $��41��6s   $��2��6�   ���	#FF000131���	#FF007399$��Stencil)�6�   $��20(�6�   $��78,0,78,167q�6�   �� 5   
   -   5        $
 Hard��5      $
��Hard��6   $��Center=�6.   $��Bottom=�6L   $	��196��6g   $��41��6s   $��2��6�   ���	#FF000131���	#FF007399$��Stencil)�6�   $��20(�6�   $��
78,0,78,51q�6�   �� 5   
   -   5        $ Custom��5      $��custom��6!   $��Center=�62   $��Bottom=�6P   $	��196��6k   $��41��6w   $��2��6�   ���	#FF000131���	#FF007399$��Stencil)�6�   $��20(�6�   $��78,0,78,400q�6�   $��3��6  �� 5   
   -   5        $ SoundBtn��5      $�� ��6#   $
��Left=�6.   $��39��6I   $��291,382,0,0q�6V   $��2��6k   $��3��6x   $	��Top=�6�   $��41��6�   ��6�   Z� ��6�   Z� 5      5      