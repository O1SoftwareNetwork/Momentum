export async function getHealthMessage() {
    const res = await fetch('/api/health');
    if (!res.ok) {
        return null;
    }
    return await res.json() as {message: string};
}