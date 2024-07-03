import { Context } from "..";

export async function changeMessage({ state, effects }: Context) {
    const res = await effects.sample.effects.getHealthMessage();
    if (!res) {
        state.sample.message = 'backend failed';
        return;
    }
    state.sample.message = res.message;
}