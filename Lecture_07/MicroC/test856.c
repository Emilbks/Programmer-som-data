void main() {
	int x;
	int y;
	y = 0;
	x = 2;

	switch (x) {
		case 1: 
			{ y = 1; }
		case 2: 
			{ y = 2; }
	}

	print y;
	print(true ? 1 : 2);
}