import { IContext } from 'overmind';
import {
	createActionsHook,
	createEffectsHook,
	createStateHook,
} from 'overmind-react';
import { namespaced } from 'overmind/config';

import * as sample from './sample';
import * as application from './application';

export const config = {
	sample,
	application,
};

export const overmindConfig = namespaced(config);
export type Context = IContext<typeof overmindConfig>;

export const useState = createStateHook<Context>();
export const useActions = createActionsHook<Context>();
export const useEffects = createEffectsHook<Context>();
