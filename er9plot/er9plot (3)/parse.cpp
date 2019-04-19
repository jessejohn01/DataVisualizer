/********************
* Electronic Realization llc
* Cy Drollinger
* cy@elec-real.com
* Text parsing of erit hardware
* 10_4_12
*******************/
#include<stdio.h>
#include<stdlib.h>
union PackByte
{
 int TwoWords;
 struct 
 	{
    char FirstByte;
    char SecondByte;
  	char ThirdByte;
    char FourthByte;
	};
struct
	{
	unsigned bit_1 :1;
	unsigned bit_2 :1;
	unsigned bit_3 :1;
	unsigned bit_4 :1;
	unsigned bit_5 :1;
	unsigned bit_6 :1;
	unsigned bit_7 :1;
	unsigned bit_8 :1;
	unsigned bit_9 :1;
	unsigned bit_10 :1;
	unsigned bit_11 :1;
	unsigned bit_12 :1;
	unsigned bit_13 :1;
	unsigned bit_14 :1;
	unsigned bit_15 :1;
	unsigned bit_16 :1;
	unsigned bit_17 :1;
	unsigned bit_18 :1;
	unsigned bit_19 :1;
	unsigned bit_20 :1;
	unsigned bit_21 :1;
	unsigned bit_22 :1;
	unsigned bit_23 :1;
	unsigned bit_24 :1;
	unsigned bit_25 :1;
	unsigned bit_26 :1;
	unsigned bit_27 :1;
	unsigned bit_28 :1;
	unsigned bit_29 :1;
	unsigned bit_30 :1;
	unsigned bit_31 :1;
	unsigned bit_32 :1;
	};
 };

int convert(char *);

#define MaxChar  100					//Max number of characters on line 
#define zero  0x00
#define one   0x01
#define data_error 0xFFFFFFFF

void main(void)
{

FILE *infile, *outfile,*outfile1,*outfile2,*outfile3,*outfile4;

char xA[5],yA[5],zA[5],tD[5],xG[5],yG[5],zG[5],xM[5],yM[5],zM[5],index[5],LineBuffer[MaxChar];
int m,count=0,XAint, YAint, ZAint, Tint, XGint, YGint, ZGint, XMint, YMint, ZMint, buffIndex;
double time,xAcceleration,yAcceleration,zAcceleration,celsius,xOmega,yOmega,zOmega,xHeading,yHeading,zHeading;


if((infile = fopen("data.csv", "r")) == NULL)

	{
	printf("Is the Inertial unit plugged into USB?\n bummer executable needs changed, ok.\n");
	exit(1);
	}

if((outfile1 = fopen("accelerate.txt","w" )) == NULL)
	{
		printf("cant open output file, a.\n");
		exit(1);
	}

if((outfile2 = fopen("gyrate.txt","w" )) == NULL)
	{
		printf("cant open output file,g .\n");
		exit(1);
	}
if((outfile3 = fopen("magnetic.txt","w" )) == NULL)
	{
		printf("cant open output file, m.\n");
		exit(1);
	}
if((outfile4 = fopen("temp.txt","w" )) == NULL)
	{
		printf("cant open output file, t.\n");
		exit(1);
	}

	fprintf(outfile1,"function accelerate() {\n return \"\" +\n");
	fprintf(outfile1,"\"Time,X,Y,Z\\n\" +\n");
	fprintf(outfile2,"function angularVelocity() {\n return \"\" +\n");
	fprintf(outfile2,"\"Time,X,Y,Z\\n\" + \n");
	fprintf(outfile3,"function magnetometer() {\n return \"\" +\n");
	fprintf(outfile3,"\"Time,X,Y,Z\\n\" +\n");
	fprintf(outfile4,"function temperature() {\n return \"\" +\n");
	fprintf(outfile4,"\"Time,Temperature\\n\" +\n");	
	
	while(fgets(LineBuffer, MaxChar, infile) != NULL)
{
	
time = (double)count*.01;
count++;
buffIndex = 0;
m = 0;
//CONVERT Acceleration from 5 character of ascii to int 32bits
while(LineBuffer[buffIndex] != ',')
{
	xA[buffIndex] = LineBuffer[buffIndex];
	buffIndex++;
	xA[buffIndex] = ',';
}
	buffIndex++;
	m = 0;
	XAint = convert(xA);
	xAcceleration = ((double)XAint/2046);
	
while(LineBuffer[buffIndex] != ',')
{
	yA[m] = LineBuffer[buffIndex];
	buffIndex++;
	m++;
	yA[m] = ',';
}	
	buffIndex++;
	m=0;
	YAint = convert(yA);
	yAcceleration = ((double)YAint/2046);
	
while(LineBuffer[buffIndex] != ',')
{
	zA[m] = LineBuffer[buffIndex];
	buffIndex++;
	m++;
	zA[m] = ',';
}
	buffIndex++;
	m = 0;
	ZAint = convert(zA);
	zAcceleration = ((double)ZAint/2046);
	
while(LineBuffer[buffIndex] != ',')
{
	tD[m] = LineBuffer[buffIndex];
	buffIndex++;
	m++;
	tD[m] = ',';
}
	buffIndex++;
	m = 0;
	Tint = convert(tD);
	celsius = (double)Tint/340 + 35;

//CONVERT Angular Velocity from 5 character of ascii to int 32bits	
while(LineBuffer[buffIndex] != ',')
{
	xG[m] = LineBuffer[buffIndex];
	buffIndex++;
	m++;
	xG[m] = ',';
}
	buffIndex++;
	m = 0;
	XGint = convert(xG);
	xOmega = (double)XGint/16.4;
	
while(LineBuffer[buffIndex] != ',')
{
	yG[m] = LineBuffer[buffIndex];
	buffIndex++;
	m++;
	yG[m] = ',';
}	
	buffIndex++;
	m = 0;
	YGint = convert(yG);
	yOmega = (double)YGint/16.4;
	
while(LineBuffer[buffIndex] != ',')
{
	zG[m] = LineBuffer[buffIndex];
	buffIndex++;
	m++;
	zG[m] = ',';
}
	buffIndex++;
	m = 0;
	ZGint = convert(zG);
	zOmega = (double)ZGint/16.4;
	
//CONVERT Magnotometers from 5 character of ascii to int 32bits
while(LineBuffer[buffIndex] != ',')
{
	xM[m] = LineBuffer[buffIndex];
	buffIndex++;
	m++;
	xM[m] = ',';
}
	buffIndex++;
	m = 0;
	XMint = convert(xM);
	xHeading = (double)XMint*(.3e-6/8);
	
while(LineBuffer[buffIndex] != ',')
{
	yM[m] = LineBuffer[buffIndex];
	buffIndex++;
	m++;
	yM[m] = ',';
}	
	buffIndex++;
	m = 0;
	YMint = convert(yM);
	yHeading = (double)YMint*(.3e-6/8);
	
while(LineBuffer[buffIndex] != ',')
{
	zM[m] = LineBuffer[buffIndex];
	buffIndex++;
	m++;
	zM[m] = ',';
}
	buffIndex++;
	m = 0;
	ZMint = convert(zM),
	zHeading = (double)ZMint*(.3e-6/8);	
	
	fprintf(outfile1,"\"%.2f,%2.5f,%2.5f,%2.5f\\n\" +\n", time, xAcceleration, yAcceleration, zAcceleration);
	fprintf(outfile2,"\"%.2f,%2.5f,%2.5f,%2.5f\\n\" +\n", time, xOmega, yOmega, zOmega);
	fprintf(outfile3,"\"%.2f,%0.8f,%0.8f,%0.8f\\n\" +\n", time, xHeading, yHeading, zHeading);
	fprintf(outfile4,"\"%.2f,%2.2f\\n\" +\n", time, celsius);
}

	fprintf(outfile1,"\"%.2f,%2.5f,%2.5f,%2.5f\\n\";\n}", time, xAcceleration, yAcceleration, zAcceleration);
	fprintf(outfile2,"\"%.2f,%2.5f,%2.5f,%2.5f\\n\";\n}", time, xOmega, yOmega, zOmega);
	fprintf(outfile3,"\"%.2f,%0.8f,%0.8f,%0.8f\\n\";\n}", time, xHeading, yHeading, zHeading);
	fprintf(outfile4,"\"%.2f,%2.2f\\n\";\n}", time, celsius);
	
fclose(infile);
fclose(outfile1);
fclose(outfile2);
fclose(outfile3);
fclose(outfile4);

//Appending the four data files into a single data.js file
if((infile = fopen("accelerate.txt","r" )) == NULL)
	{
		printf("cant open output file, t.\n");
		exit(1);
	}

if((outfile = fopen("data.js","a" )) == NULL)
	{
		printf("cant open output file, t.\n");
		exit(1);
	}
	else
	{
	while(fgets(LineBuffer, MaxChar, infile) != NULL)	
	{
		fprintf(outfile,"%s",LineBuffer);
	}	
	fprintf(outfile,"\n\n");
	}
	fclose(infile);
	
	if((infile = fopen("gyrate.txt","r" )) == NULL)
	{
		printf("cant open output file, t.\n");
		exit(1);
	}
	
	while(fgets(LineBuffer, MaxChar, infile) != NULL)	
	{
		fprintf(outfile,"%s",LineBuffer);
	}	
	fprintf(outfile,"\n\n");
	
	fclose(infile);
	
	if((infile = fopen("magnetic.txt","r" )) == NULL)
	{
		printf("cant open output file, t.\n");
		exit(1);
	}
	
	while(fgets(LineBuffer, MaxChar, infile) != NULL)	
	{
		fprintf(outfile,"%s",LineBuffer);
	}	
	fprintf(outfile,"\n\n");
	
	fclose(infile);

	if((infile = fopen("temp.txt","r" )) == NULL)
	{
		printf("cant open output file, t.\n");
		exit(1);
	}
	
	while(fgets(LineBuffer, MaxChar, infile) != NULL)	
	{
		fprintf(outfile,"%s",LineBuffer);
	}	
	fprintf(outfile,"\n\n");
	
	fclose(infile);
	fclose(outfile);
}

	
int convert(char *char_buffer)
{	int m = 0, thirtytwo = 0;
	union PackByte temp;
	temp.TwoWords = 0;
		
	while(char_buffer[m] != ',')									
	{
	m++;
	}																//determines the number of ascii characters for the number
	switch(m)
				  {
						case 0: temp.TwoWords = 0x00000000;
						case 1: temp.TwoWords = (int)(1*char_buffer[0] - '0');break;				//
						case 2: temp.TwoWords = (int)(10*(char_buffer[0] - '0') + 1*(char_buffer[1] - '0'));break;			//
						case 3: temp.TwoWords = (int)(100*(char_buffer[0] - '0') + 10*(char_buffer[1] - '0') + 1*(char_buffer[2] - '0'));break;		//
						case 4: temp.TwoWords = (int)(1000*(char_buffer[0] - '0') + 100*(char_buffer[1] - '0') + 10*(char_buffer[2] - '0') + 1*(char_buffer[3] - '0'));break;		//
						case 5: temp.TwoWords = (int)(10000*(char_buffer[0] - '0') + 1000*(char_buffer[1] - '0') + 100*(char_buffer[2] - '0') + 10*(char_buffer[3] - '0') + 1*(char_buffer[4] - '0'));break;
						default: temp.TwoWords = 0xFFFFFFFF;break;
				  }
	thirtytwo = ((int)(0x7FFF) & temp.TwoWords) - ((0x8000 & temp.TwoWords) ? 32768 : 0);
	
return( thirtytwo );	
}
	
