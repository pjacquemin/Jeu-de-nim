   M S B A M L   `   `   `  ����  JeuDeNim%    JeuDuMoulin.PartiesSauvegardees   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��640��5      $	��480��6     N� Title$  PartiesSauvegardees��5	      .��5      � .+�5   
   � -   5         �Name$ 
LayoutRoot��5      
�������.+�5      �� $��Images/jeu-nim.jpg��6   $
��Fill=�60    J� Opacity$	 0.5Q�6?   �� 5      $��Parties sauvegardées��6   $
��Left=�63   $��	30,30,0,0q�6N   $	��Top=�6a   $��Showcard Gothic)�6y   $
��Bold"�6�   $��29.333(�6�   ���	#FFB224246�   �� 5      -   5         ��Name$ bCharger��5      $��Charger��6'   $��283,0,282,82q�69   $��Bottom=�6O   $��Tempus Sans ITC)�6j   5      �� 5      -   5        $ bSupp��5      $��	Supprimer��6$   $��283,0,282,55q�68   $��Bottom=�6N   $��Tempus Sans ITC)�6i   5      �� 5      -   5        $ bRetour��5      $��Retour��6&   $��283,0,282,28q�67   $��Bottom=�6M   $��Tempus Sans ITC)�6h   5      &   System.Windows.Controls.DataGrid  5      -   5        $��	dataGrid1��5   s   $	 0.5Q�6      AutoGenerateColumns .  $
��Left=�6A   $��160,109,0,110q�6\   $	��314��6�   ��6�   ��  � DataContext 6�   ��  �� Path$ 
sauvegarde�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Nom partie��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 120 6`   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6=   �� $ 	NomPartie�6`     5       $ Votre score��6)   $	 90 6^   
 6>   �� $ ScoreJ�6^     5!      $ Votre score��6)   $		 100 6^   
 6>   �� $ ScoreO�6^   5#      5$      5%      5&      