   M S B A M L   `   `   `  ����E  ACryptoInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CryptoInfo
CryptoInfo  5	          CryptoInfo.MainView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:CryptoInfo     5	      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5
      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      $	��600��5        � Title$
  Home��5      $	��700��5       � 	Resources 5       �� 
TargetType   HeadingLabels �� Property �� Value&   System.Windows.Controls.DataGrid��%�   &	        '  �     �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 24(�6)   �� 5       � ��$ Center=�6;   5      �� 5   
   "  6   .�5      ��  � ��
 ���� 6+   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��85 �6   �� 5      $��* �6   .+�5   
   �� ���#151c24$��0��5       �� Orientation$ Vertical=�5      .+�5      �� 
������ $��0q�5!      $��24(�5"      
�������$��Center=�5$      .��65   Home5&      5'      �� 5(   
   ���#202a36$��1��5*      $ Vertical=�5+      .+�5,      �� $��40��6   .+�5-      �� $��Top 10 Currencies��6   #��[  64   5.      �� 5/        50         AutoGenerateColumns$ False��51         CanUserAddRows$ False��52      $��10q�54      #��[B 55      ��53      �� *	Cryptos+ 56      *  $System.Windows.Controls.DataGridCell	 �� Triggers
 P� Property P� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�  '        '  .    �� 57      "  6   .�58      ��  � ��
 ���� 67   �� 59       � �� �#eb5d2167   �� 5:       � ��$ 14(�65   	 5;      P� 5<      
 �@ 
IsSelected$
 True��6<   . �5=   "   ��  � ��
 ���� 6?   �� 5>   "    � ��
 �����6?   5?      5A      �� 5B      "  6   .�5C      ��  � ��
 ���� 67   �� 5D       � �� �#eb5d2167   �� 5E       � ��$ 10q�63   5F      5G         Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Header$
 Rank��6B   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *rank+6B     5J      $ Symbol��6D    6)   �� *symbol+6D     5K      $
 Name��6R    6)   �� *name+ �� StringFormat$ C��6R     5L      $ Price (USD)��6V    6)   �� *
priceUsd+$ C��6V     5M      $ 24h Volume (USD)��6[    6)   �� *volumeUsd24Hr+$ C��6[   5O      5P      5R      5S      