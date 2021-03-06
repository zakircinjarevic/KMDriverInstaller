KONICA MINOLTA 4020_3320 PS/PCL/XPS Printer Driver
=======================================================
Ver. 1.7.0

Installation Note
==================
- Close all other programs before beginning setup.



Common for PS/PCL/XPS driver
============================

- The setting value of the following function is saved to the registry in accordance with specifications.
Therefore, when the following function is set from print dialog of an application, the setting value is reflected in [Properties -> Printing Preference].

- To use Job Accounting, enable Job Accounting setting on the printer.
For more detail refer to the user manual.


Common for PS/PCL driver
========================

- In the environment that printer drivers installed via "Point and Print"
method, please edit "Favorite Setting" or "Watermark" in Printers folder, previously.

- To do collating by printer...
Disable collate settings in application if available, enable collate settings
in printer driver.

- If the font in the document is not printed as expected, try to change following options.
  Quality Tab -> Font Settings -> Download Font Format: change to Bitmap
  Quality Tab -> Font Settings -> Use Printer Fonts: change to disable

- Configure the following settings for stapling multiple copies:

Uncheck "File" -> "Print" -> "Collate".
Check "File" -> "Print" -> "Printer Property" -> "Collate" in Basic setting.

- Watermark may not be printed with a combination of the following functions.
In this case, set Watermark Density to Dark and Transparent to Off, or change setting of the following functions:

Zoom, N-up, Binding Margin

- When you print both sides of thin paper or recycled paper of 64g/m2 or less in a high temperature and high humidity environment, please select "Recycled" in [Paper Type].


Notes for PS driver
===================

- There are the following limitations for "Booklet" printing:

Configure "Property" -> "Advanced Tab" -> "Postscript pass through" to "Disable" and print.
It may not be printed properly with specifying "gradient" for "fill color" with Microsoft Office applications.

- If the spool data exceeds few hundred mega bytes, it may cause a warning
(insufficient memory) upon your system environment.
To solve this problem, turn the following option disabled.
  Advanced Tab -> Advanced Printing Features
  Properties -> Advanced Tab -> Enable advanced printing features


- "Booklet" cannot be used with the following setting.
  Port: SMB or Internet Port
  Advanced Tab -> Advanced Printing Features: Disabled
  Properties -> Advanced Tab -> Enable advanced printing features: Not checked

- In the "Point and Print" environment, there is
a case that the "Collate" function of printer driver may not work when using Microsoft Word.
In such case, please print with application's collate ON.

- In File Maker 4.0, please set the "Binding Position" from Printers folder.

- The following limitations exist using Adobe Acrobat or Adobe Reader.
  You may not be able to print correctly. If printing fails, 
  select [Print as image] in the Advanced Print dialog box of the application.


Notes for PCL driver
====================

- In CorelDRAW application, it will take long time to print the document or cause "PCL XL
error (InsufficientMemory)" if the pattern like gradation is used to fill the object.
To solve this problem, please set CorelDRAW option as follows;
  File->Print->Misc : Check "Rasterize entire page"

- In Microsoft Publisher, imported JPEG image may be printed upside down.
In this case, please resize the image in another application prior to import into Publisher.

- When reduced printing is implemented in Microsoft Word/Excel,
a thin line such as a ruled line may not be printed.
When reduced printing is implemented in Microsoft Excel, a thin line such as a ruled line 
may be printed if you set original size of basic tab to be same as the paper size.
When reduced printing is implemented in Microsoft Word, a thin line such as a ruled line 
may be printed if you use enlargement/reduction function in the Print dialogue of Word.


Notes and Restrictions for XPS Printer Driver
=============================================

- When you print a file with much number of pages via LAN,
  the error of the timeout occurs by restriction of OS
  and you may not be able to print.
  In that case, please use it by making the time of the timeout of the machine long.

- Please enter the value more than 5mm for the left, right, top and bottom of margin, even though
  it can set
  margin at 0mm when this XPS printer driver is selected in an application which is able to set margin
  such as Microsoft Word.
  If margin is set less than 5mm, nothing is printed in the area of 5mm inside from the left, right, top
  and bottom.

- Following results may occur when printing by this XPS printer driver.
    A part of the document data is missing.
    The part that is transparent with the original is printed without being transparent.
    The line which is not on the original is printed.

- If outputting to the file by checking [Enable bidirectional support] of [Ports] tab,
  it may take a considerable time by restriction of OS.
  Please use it by un-checking [Enable bidirectional support] of [Ports] tab
  when outputting to the file.

- Cannot print by restriction of OS if checking [Print directly to the printer] of [Advanced] tab.

- The following functions have not been supported in WPF application (XPS Viewer, etc.).
    [Watermark/Overlay] tab-[Create Overlay]
    [Configure] tab-[Acquire Settings]-[Auto]


Notes for Printer
====================

- Please close the spooler when you print by the XPS driver for Windows Vista/7/8/8.1/10/Server 2008/Server 2008R2/Server 2012/Server 2012R2/Server 2016 via IPP.
It may not be printed properly if you send jobs with the spooler opened.
In that case, open the spooler in the Administrator mode, delete any jobs, close the spooler, and then send jobs.

- An error page may be output when you print a number of pages using IPP port on Windows Vista/7/8/8.1/10/Server 2008/Server 2008R2/Server 2012/Server 2012R2/Server 2016.
Use Raw port or LPR port.
If you want to print consecutively, print at intervals.

- For IPP print, select "Add Printer" from "Printer and FAX", install printer driver by setting port at the "Add Printer Wizard".

- Printing may end prematurely if you print a number of pages via WSD on Windows Vista/7/8/8.1/10/Server 2008/Server 2008R2/Server 2012/Server 2012R2/Server 2016.
Change the port to print.


OS  Restrictions
=============================================

- Wartermark in PCL driver for x64 Edition
When printing the document with odd number of pages with specifying [Duplex] and
[Watermark], a blank page would be added after the last page and the watermark 
would be printed on the blank page.

- Watermark on x64
When printing with Copy Track authentication from 32bit application running 
on x64, the Watermark might not be printed 
correctly.

- PS Driver
There will be a blank space in the window since the window size of 
the Print Setting is bigger that the other drivers. This will have no effect
on the print operation.

- Using a WSD Port Connection
The Printer Driver must be installed in order to connect to the device using 
the WSD port.

- About Watermark printing
 In some instances, the Watermark is not printed when the print is executed
 from Microsoft Word or Microsoft Excel.
 - Printer Property -> [Settings]Tab - [EMF Spool] -> ON
 - Printer Property -> [Advaced]Tab - [Enable advanced printing features] -> ON

- Restriction of Cover Sheet in x86
 In some instances, the Cover Sheet is not printed when the print is
 executed from Microsoft Word or Microsoft Excel.

- Restriction of Printer Icon
 When you installed the printer driver, the printer icon may not be 
 displayed at [Devices and Printers] shortly after installing. This phenomenon can 
 be solved if you configure the settings by the following steps before installing 
 the printer driver.
 1. Swipe in from the right edge of the screen, and then tap [Settings]. 
    Or, if you are using a mouse, point to the lower-right corner of the screen, 
    and then click [Settings].
 2. Tap or click [PC info].
 3. Tap or click [Advanced system settings] on the left of the window.
 4. Tap or click the [Hardware] tab in [System Properties].
 5. Tap or click the [Device Installation Settings] button.
 6. Select [No, let me choose what to do], and specify [Never install driver 
    software from Windows Update.] from the options. Moreover, un-check 
    [Automatically get the device app and info provided by your device 
    manufacturer.].
    *After changing the settings, please restart the computer before installing 
     the printer driver.
    *Once the printer icon has been displayed after installing the printer driver 
     by these settings, please turn back the settings of 
     [Device Installation Settings].


Cautions and restrictions with specific applications
======================================================

Microsoft Office
- AutoShapes Graphics Print in Office [* PS Driver only]
If the [Transparency] check box of [Fill] column in [Format AutoShape...]-
[Colors and Lines]tab is ON, the paint-out part of graphics may not be
printed correctly at the time of reduction and enlargement print.

- Continuous Print by Microsoft Word 2000
If you print by pressing the print bottom continuously in Microsoft Word 2000, 
the omission of text and object or the page may occur.  When you print continuously 
by using the print bottom, set the [Background Printing] check box to ON in 
[Tools]-[Options]-[Print]tab and then perform printing.
Or perform the continuous print of same original with setting the Copies to print 
by using the Print dialog box in [File]-[Print...].

- Entire workbook Print in Microsoft Excel
When you print the Microsoft Excel document that has different binding direction 
in each sheets with the [Entire workbook] checkbox ON, it may not be printed 
as you specified.

- Duplex Print in Microsoft Word 2007 or Microsoft Word 2010
When a document with odd number sheet is printed in duplex mode from
Microsoft Word 2007 or Microsoft Word 2010, white paper which is not included 
in original may be printed and counted.

- Custom Size printing in Microsoft Word
When paper size is specified as "Custom Size", it may be printed in invert.
In this case, it can be printed normally when paper size is specified as
"Same as Original Size".

Adobe Acrobat
- Depending on the PDF file, the background may be painted with white out.
When the topside of this image is printed during overlay print, the downside 
of the image (Original or Overlay) cannot be printed.

- When printing the PDF file with turning off the "Choose Paper Source by PDF page 
size" checkbox in the "Print" dialog, the page with different direction from 
the 1st page and following pages might not be printed with correct direction 
since Acrobat Reader will not correctly notify the page direction of pages 
after the 1st page to the printer driver.

- When printing landscape original using Acrobat Reader 9, the page will be rotated 
first then printed.[*PCL/XPS only]
This means for example that staple or punch may be made in the different 
position of the document from the expected one.
==>In this case, it can be printed normally when [Auto-Rotate and Center] is 
  specified to OFF in the [Print Setting] of application.

- When printing landscape original using Acrobat Reader 9 on 
Windows Vista x64 SP2, the first page will be printed as portrait original.
==>In this case, it can be printed normally when [Auto-Rotate and Center] is 
   specified to OFF in the [Print Setting] of application.

- Please note that entering multiple copies in the Print Dialog menu will not 
yield the expected results when using Adobe Reader X or Adobe Acrobat X. 
==>When printing a multiple number of copies using Adobe Reader X or
   Adobe Acrobat X, you need to configure the [Page Setup] setting first and 
   then configure the Printer Driver Properties menu.  

Adobe PageMaker, Illustrator
- Depending on applications, such as Adobe PageMaker, Illustrator and etc, 
if it recognizes that it is a PostScript printer driver, the application itself 
may output PostScript commands. In this case, it may not be printed correctly.
[* PS Driver only]

- When the Illustrator file with paper size A0/A1/B1 is printed with Illustrator CS, 
a part of the image is lost.
With Illustrator CS2 or more, this problem doesn't occur.

Internet Explorer, Note Pad
- Check the selected printer when printing continuously by the Internet Explorer
or Note Pad.
Selected printer might differ from the previous selection if several same
printer drivers have been installed, depending on the application limitation.
==>In this case, change the printer driver name with 
   which selection will be changed, to less than 29 characters.

Word97
- Unable to print by Word97.
Word2000 or more is required for the printing by the Word.

Excel
- Check the print settings before printing when you print from Excel after 
switching the printer driver.
Depending on the limitation of application, current printer driver setting might 
apply to the printer driver after switching.
==>In that case, change the name of a printer driver used to within 29 characters. 

PowerPoint
- The background of PowerPoint data is painted with the specified color.
Because of this, when the topside of this image is printed during the overlay
print with white background,the bottom of the image (Original or Overlay) cannot
be printed by combination of the following driver.
 - PowerPoint2007 later  ->  PS/PCL driver

Others
- Blank Page
According to the application to use, when the data has odd number pages, 
it may be added the blank paper if [2-Sided] function is available.
In that case, the following phenomenon will occur.
 - The Watermark will be printed on the last blank page.
  (in case of specifying The [Watermark] function)
  - The Overlay will be printed on the last blank page.
  (in case of specifying The [Overlay] function).


* Company names and product names in this document are the registered trademarks for
respective companies.
------------------------------------------------------------
Copyright(C) 2013 KONICA MINOLTA, INC.
All rights reserved.
