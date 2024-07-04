function Logo(props: { useAsLoader?: boolean }) {
	return (
		<svg
			version='1.0'
			xmlns='http://www.w3.org/2000/svg'
			viewBox='0 0 500.000000 500.000000'
			preserveAspectRatio='xMidYMid meet'
		>
			<g
				transform='translate(0.000000,500.000000) scale(0.100000,-0.100000)'
				stroke='none'
				fill={'#066868'}
			>
				<path
					className={props.useAsLoader ? 'path1' : ''}
					d='M3445 4623 c-360 -46 -616 -246 -726 -567 -53 -154 -59 -229 -59
-797 l0 -516 107 -6 c58 -4 210 -7 338 -7 l232 0 6 203 c4 111 7 344 7 517 0
284 2 319 19 355 24 54 70 91 137 111 72 21 136 7 192 -42 56 -47 72 -101 72
-234 l0 -107 182 -6 c99 -4 252 -7 339 -7 l157 0 4 78 c27 593 -242 959 -752
1022 -81 10 -193 11 -255 3z'
				/>
				<path
					className={props.useAsLoader ? 'path2' : ''}
					d='M3757 2993 c-4 -256 -7 -670 -7 -918 l0 -452 98 -6 c53 -4 205 -7
338 -7 l241 0 6 242 c4 133 7 549 7 925 l0 683 -338 0 -339 0 -6 -467z'
				/>
				<path
					className={props.useAsLoader ? 'path3' : ''}
					d='M1210 3049 c-320 -41 -571 -229 -690 -517 -64 -151 -67 -191 -75
-811 l-8 -561 347 0 346 0 0 501 c0 352 3 513 12 540 52 176 303 201 386 39
19 -39 22 -60 22 -167 l0 -123 347 0 346 0 -6 168 c-7 189 -25 297 -69 419
-51 141 -158 284 -270 361 -181 124 -447 182 -688 151z'
				/>
				<path
					className={props.useAsLoader ? 'path4' : ''}
					d='M2660 2207 c0 -528 -2 -549 -50 -617 -27 -38 -111 -80 -160 -80 -86
0 -154 40 -193 114 -18 35 -21 58 -22 161 l0 120 -342 3 -343 2 0 -137 c0 -76
5 -172 10 -213 41 -314 189 -539 435 -659 267 -131 625 -129 886 5 200 103
343 276 413 500 39 127 45 212 50 772 l5 522 -345 0 -344 0 0 -493z'
				/>
			</g>
		</svg>
	);
}

export default Logo;
