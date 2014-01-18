using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CargarComprador
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {
            string h = @"{\rtf1\ansi\ansicpg1252\uc1\deff0\stshfdbch0\stshfloch0\stshfhich0\stshfbi0\deflang3082\deflangfe3082{\fonttbl{\f0\froman\fcharset0\fprq2{\*\panose 02020603050405020304}Times New Roman;}{\f36\froman\fcharset238\fprq2 Times New Roman CE;}";
            h += @"{\f37\froman\fcharset204\fprq2 Times New Roman Cyr;}{\f39\froman\fcharset161\fprq2 Times New Roman Greek;}{\f40\froman\fcharset162\fprq2 Times New Roman Tur;}{\f41\froman\fcharset177\fprq2 Times New Roman (Hebrew);}";
            h += @"{\f42\froman\fcharset178\fprq2 Times New Roman (Arabic);}{\f43\froman\fcharset186\fprq2 Times New Roman Baltic;}{\f44\froman\fcharset163\fprq2 Times New Roman (Vietnamese);}}{\colortbl;\red0\green0\blue0;\red0\green0\blue255;\red0\green255\blue255;";
            h += @"\red0\green255\blue0;\red255\green0\blue255;\red255\green0\blue0;\red255\green255\blue0;\red255\green255\blue255;\red0\green0\blue128;\red0\green128\blue128;\red0\green128\blue0;\red128\green0\blue128;\red128\green0\blue0;\red128\green128\blue0;";
            h += @"\red128\green128\blue128;\red192\green192\blue192;}{\stylesheet{\ql \li0\ri0\widctlpar\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0 \fs24\lang3082\langfe3082\cgrid\langnp3082\langfenp3082 \snext0 Normal;}{\*\cs10 \additive \ssemihidden ";
            h += @"Default Paragraph Font;}{\*\ts11\tsrowd\trftsWidthB3\trpaddl108\trpaddr108\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\trcbpat1\trcfpat1\tscellwidthfts0\tsvertalt\tsbrdrt\tsbrdrl\tsbrdrb\tsbrdrr\tsbrdrdgl\tsbrdrdgr\tsbrdrh\tsbrdrv ";
            h += @"\ql \li0\ri0\widctlpar\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0 \fs20\lang1024\langfe1024\cgrid\langnp1024\langfenp1024 \snext11 \ssemihidden Normal Table;}}{\*\latentstyles\lsdstimax156\lsdlockeddef0}{\*\listtable";
            h += @"{\list\listtemplateid-1569709602\listhybrid{\listlevel\levelnfc0\levelnfcn0\leveljc0\leveljcn0\levelfollow0\levelstartat1\levelspace0\levelindent0{\leveltext\leveltemplateid201981967\'02\'00.;}{\levelnumbers\'01;}\fbias0 \fi-360\li720";
            h += @"\jclisttab\tx720\lin720 }{\listlevel\levelnfc4\levelnfcn4\leveljc0\leveljcn0\levelfollow0\levelstartat1\levelspace0\levelindent0{\leveltext\leveltemplateid201981977\'02\'01.;}{\levelnumbers\'01;}\fi-360\li1440\jclisttab\tx1440\lin1440 }{\listlevel";
            h += @"\levelnfc2\levelnfcn2\leveljc2\leveljcn2\levelfollow0\levelstartat1\levelspace0\levelindent0{\leveltext\leveltemplateid201981979\'02\'02.;}{\levelnumbers\'01;}\fi-180\li2160\jclisttab\tx2160\lin2160 }{\listlevel\levelnfc0\levelnfcn0\leveljc0\leveljcn0";
            h += @"\levelfollow0\levelstartat1\levelspace0\levelindent0{\leveltext\leveltemplateid201981967\'02\'03.;}{\levelnumbers\'01;}\fi-360\li2880\jclisttab\tx2880\lin2880 }{\listlevel\levelnfc4\levelnfcn4\leveljc0\leveljcn0\levelfollow0\levelstartat1\levelspace0";
            h += @"\levelindent0{\leveltext\leveltemplateid201981977\'02\'04.;}{\levelnumbers\'01;}\fi-360\li3600\jclisttab\tx3600\lin3600 }{\listlevel\levelnfc2\levelnfcn2\leveljc2\leveljcn2\levelfollow0\levelstartat1\levelspace0\levelindent0{\leveltext";
            h += @"\leveltemplateid201981979\'02\'05.;}{\levelnumbers\'01;}\fi-180\li4320\jclisttab\tx4320\lin4320 }{\listlevel\levelnfc0\levelnfcn0\leveljc0\leveljcn0\levelfollow0\levelstartat1\levelspace0\levelindent0{\leveltext\leveltemplateid201981967";
            h += @"\'02\'06.;}{\levelnumbers\'01;}\fi-360\li5040\jclisttab\tx5040\lin5040 }{\listlevel\levelnfc4\levelnfcn4\leveljc0\leveljcn0\levelfollow0\levelstartat1\levelspace0\levelindent0{\leveltext\leveltemplateid201981977\'02\'07.;}{\levelnumbers\'01;}";
            h += @"\fi-360\li5760\jclisttab\tx5760\lin5760 }{\listlevel\levelnfc2\levelnfcn2\leveljc2\leveljcn2\levelfollow0\levelstartat1\levelspace0\levelindent0{\leveltext\leveltemplateid201981979\'02\'08.;}{\levelnumbers\'01;}\fi-180\li6480\jclisttab\tx6480\lin6480 }";
            h += @"{\listname ;}\listid665714907}}{\*\listoverridetable{\listoverride\listid665714907\listoverridecount0\ls1}}{\*\rsidtbl \rsid819051\rsid1997776\rsid5395798\rsid14899533\rsid15079208}{\*\generator Microsoft Word 11.0.5604;}{\info";
            h += @"{\title Complemento de Registro de Ventas \'96 tbrBingo}{\author PC-Cordoba}{\operator PC-Cordoba}{\creatim\yr2009\mo11\dy3\hr19\min33}{\revtim\yr2009\mo11\dy3\hr19\min34}{\version3}{\edmins7}{\nofpages1}{\nofwords191}{\nofchars1052}{\nofcharsws1241}";
            h += @"{\vern24689}}\paperw11906\paperh16838\margl1701\margr1701\margt1417\margb1417 \deftab708\widowctrl\ftnbj\aenddoc\hyphhotz425\noxlattoyen\expshrtn\noultrlspc\dntblnsbdb\nospaceforul\formshade\horzdoc\dgmargin\dghspace180\dgvspace180\dghorigin1701";
            h += @"\dgvorigin1417\dghshow1\dgvshow1\jexpand\viewkind1\viewscale100\pgbrdrhead\pgbrdrfoot\splytwnine\ftnlytwnine\htmautsp\nolnhtadjtbl\useltbaln\alntblind\lytcalctblwd\lyttblrtgr\lnbrkrule\nobrkwrptbl\snaptogridincell\allowfieldendsel\wrppunct";
            h += @"\asianbrkrule\rsidroot15079208\newtblstyruls\nogrowautofit \fet0\sectd \linex0\headery708\footery708\colsx708\endnhere\sectlinegrid360\sectdefaultcl\sftnbj {\*\pnseclvl1\pnucrm\pnstart1\pnindent720\pnhang {\pntxta .}}{\*\pnseclvl2";
            h += @"\pnucltr\pnstart1\pnindent720\pnhang {\pntxta .}}{\*\pnseclvl3\pndec\pnstart1\pnindent720\pnhang {\pntxta .}}{\*\pnseclvl4\pnlcltr\pnstart1\pnindent720\pnhang {\pntxta )}}{\*\pnseclvl5\pndec\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}{\*\pnseclvl6";
            h += @"\pnlcltr\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}{\*\pnseclvl7\pnlcrm\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}{\*\pnseclvl8\pnlcltr\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}{\*\pnseclvl9\pnlcrm\pnstart1\pnindent720\pnhang ";
            h += @"{\pntxtb (}{\pntxta )}}\pard\plain \qc \li0\ri0\widctlpar\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0\pararsid15079208 \fs24\lang3082\langfe3082\cgrid\langnp3082\langfenp3082 {\b\lang1034\langfe3082\langnp1034\insrsid15079208\charrsid15079208 ";
            h += @"Complemento de Registro de Ventas \endash  tbrBingo}{\b\lang1034\langfe3082\langnp1034\insrsid5395798 ";
            h += @"\par }{\b\lang1034\langfe3082\langnp1034\insrsid15079208 ";
            h += @"\par }\pard \qj \li0\ri0\widctlpar\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0\pararsid15079208 {\lang1034\langfe3082\langnp1034\insrsid15079208 La funci\'f3n de este programa es permitir el registro de las ventas de cartones de bingo. ";
            h += @"Para utilizar el software debe seguir los siguientes pasos:";
            h += @"\par ";
            h += @"\par {\listtext\pard\plain\lang1034\langfe3082\langnp1034\insrsid15079208 \hich\af0\dbch\af0\loch\f0 1.\tab}}\pard \qj \fi-360\li720\ri0\widctlpar\jclisttab\tx720\aspalpha\aspnum\faauto\ls1\adjustright\rin0\lin720\itap0\pararsid15079208 {";
            h += @"\lang1034\langfe3082\langnp1034\insrsid15079208 Recibir los cartones junto con el archivo asociado a los mismos.";
            h += @"\par {\listtext\pard\plain\lang1034\langfe3082\langnp1034\insrsid15079208 \hich\af0\dbch\af0\loch\f0 2.\tab}Abrir el archivo con el programa, desde el men\'fa Archivo -> Abrir.";
            h += @"\par {\listtext\pard\plain\lang1034\langfe3082\langnp1034\insrsid15079208 \hich\af0\dbch\af0\loch\f0 3.\tab}Para registrar una venta, ubique el cart\'f3n en la lista, haga doble-click en las celdas que pertenecen a la misma fila del cart\'f3n e ing";
            h += @"rese los datos correspondientes al comprador.";
            h += @"\par {\listtext\pard\plain\lang1034\langfe3082\langnp1034\insrsid15079208 \hich\af0\dbch\af0\loch\f0 4.\tab}Una  vez cargados los datos de la persona, seleccione }{\i\lang1034\langfe3082\langnp1034\insrsid15079208\charrsid15079208 Guardar}{";
            h += @"\lang1034\langfe3082\langnp1034\insrsid15079208  en el men\'fa }{\i\lang1034\langfe3082\langnp1034\insrsid15079208\charrsid15079208 Archivo}{\i\lang1034\langfe3082\langnp1034\insrsid15079208 .}{\lang1034\langfe3082\langnp1034\insrsid15079208 ";
            h += @"\par {\listtext\pard\plain\lang1034\langfe3082\langnp1034\insrsid15079208 \hich\af0\dbch\af0\loch\f0 5.\tab}El programa, al volver a ejecutarlo, carga autom\'e1ticamente el }{\lang1034\langfe3082\langnp1034\insrsid14899533 \'faltimo}{";
            h += @"\lang1034\langfe3082\langnp1034\insrsid15079208  archivo abierto, para }{\lang1034\langfe3082\langnp1034\insrsid14899533 agilizar el registro de las ventas. ";
            h += @"\par {\listtext\pard\plain\lang1034\langfe3082\langnp1034\insrsid14899533 \hich\af0\dbch\af0\loch\f0 6.\tab}}\pard \qj \fi-360\li720\ri0\widctlpar\jclisttab\tx720\aspalpha\aspnum\faauto\ls1\adjustright\rin0\lin720\itap0\pararsid14899533 {";
            h += @"\lang1034\langfe3082\langnp1034\insrsid14899533 Una vez que se haya finalizado el per\'edodo de venta del Bingo, seleccione la opci\'f3n }{\i\lang1034\langfe3082\langnp1034\insrsid14899533\charrsid14899533 G}{";
            h += @"\i\lang1034\langfe3082\langnp1034\insrsid14899533 u}{\i\lang1034\langfe3082\langnp1034\insrsid14899533\charrsid14899533 ardar como}{\i\lang1034\langfe3082\langnp1034\insrsid14899533  }{\lang1034\langfe3082\langnp1034\insrsid14899533 en el men\'fa }{";
            h += @"\i\lang1034\langfe3082\langnp1034\insrsid14899533\charrsid14899533 Archivo}{\i\lang1034\langfe3082\langnp1034\insrsid14899533 . }{\lang1034\langfe3082\langnp1034\insrsid14899533  Esta acci\'f3n le permite guardar una copia";
            h += @" del archivo y cierra el mismo, lo que significa que la pr\'f3xima vez que ejecute el software la lista aparecer\'e1 vac\'eda. }{\lang1034\langfe3082\langnp1034\insrsid15079208 ";
            h += @"\par {\listtext\pard\plain\lang1034\langfe3082\langnp1034\insrsid14899533 \hich\af0\dbch\af0\loch\f0 7.\tab}}{\lang1034\langfe3082\langnp1034\insrsid14899533 Una vez que haya seleccionado }{\i\lang1034\langfe3082\langnp1034\insrsid14899533\charrsid14899533 ";
            h += @"Guardar como}{\i\lang1034\langfe3082\langnp1034\insrsid14899533  }{\lang1034\langfe3082\langnp1034\insrsid14899533 env\'ede el archivo generado al vendedor de cartones para que puede registrar en su sistema la venta de sus cartones.";
            h += @"\par }\pard \qj \li360\ri0\widctlpar\aspalpha\aspnum\faauto\adjustright\rin0\lin360\itap0\pararsid14899533 {\lang1034\langfe3082\langnp1034\insrsid14899533 ";
            h += @"\par Por cada Bingo del cual venda cartones, debe}{\lang1034\langfe3082\langnp1034\insrsid1997776 r\'e1 repetir los pasos enumerados anteriormente.}{\lang1034\langfe3082\langnp1034\insrsid14899533\charrsid15079208 ";
            h += @"\par }}";
            richTextBox1.Rtf = h;
        }
    }
}