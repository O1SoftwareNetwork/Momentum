import { useTheme } from '@mui/material';

/**
 *
 * @param props useAsLoader if animation should be used otherwise use as a static image
 * @returns
 */
function Logo(props: { useAsLoader?: boolean }) {
	const theme = useTheme();
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
				fill={theme.palette.primary.main}
			>
				<path
					className={props.useAsLoader ? 'path1' : ''}
					d='M3762 4718 c-325 -33 -614 -209 -775 -473 -49 -81 -105 -221 -128
-325 -23 -100 -38 -511 -39 -1086 l0 -351 73 -7 c39 -3 221 -6 402 -7 314 -1
330 0 333 17 1 11 6 291 10 624 l7 605 28 47 c47 81 133 128 233 128 66 0 107
-16 159 -61 64 -57 78 -103 83 -265 l4 -141 226 -6 c124 -4 303 -7 398 -7
l173 0 7 36 c11 58 -3 352 -20 444 -44 227 -128 399 -260 539 -130 136 -288
220 -501 267 -87 20 -316 31 -413 22z'
				/>
				<path
					className={props.useAsLoader ? 'path2' : ''}
					d='M4137 2908 c-4 -232 -7 -724 -7 -1093 l0 -672 77 -7 c42 -3 221 -6
398 -6 l322 0 6 197 c4 108 7 603 7 1100 l0 903 -398 0 -399 0 -6 -422z'
				/>
				<path
					className={props.useAsLoader ? 'path3' : ''}
					d='M1135 2844 c-142 -16 -290 -57 -400 -111 -269 -134 -478 -415 -530
-711 -15 -81 -27 -505 -38 -1260 l-2 -172 413 0 412 0 0 593 c0 360 4 609 11
636 14 64 59 123 118 155 131 71 284 28 348 -98 23 -45 26 -65 31 -198 l5
-148 409 0 409 0 -5 48 c-3 26 -8 111 -11 189 -16 390 -106 620 -324 825 -158
150 -407 240 -691 251 -63 3 -133 3 -155 1z'
				/>
				<path
					className={props.useAsLoader ? 'path4' : ''}
					d='M2818 1813 c-3 -462 -7 -617 -17 -647 -19 -57 -96 -129 -160 -151
-127 -42 -255 14 -310 135 -17 38 -21 66 -21 183 l0 137 -262 0 c-145 0 -327
3 -405 7 l-143 6 0 -169 c0 -93 5 -208 10 -254 55 -449 318 -755 737 -860 198
-49 411 -48 618 5 366 93 636 368 725 740 28 115 38 326 45 938 l7 537 -411 0
-410 0 -3 -607z'
				/>
			</g>
		</svg>
	);
}

export default Logo;
