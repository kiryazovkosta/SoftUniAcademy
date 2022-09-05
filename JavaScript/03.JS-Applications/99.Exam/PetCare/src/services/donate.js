import * as api from '../api.js';

const endpoints = {
    create: '/data/donation',
    count: (petId) => `/data/donation?where=petId%3D%22${petId}%22&distinct=_ownerId&count`,
    byUser: (petId, userId) => `/data/donation?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`
}

export async function countAll(petId) {
    return api.get(endpoints.count(petId));
}

export async function count(petId, userId) {
    return api.get(endpoints.byUser(petId, userId));
}

export async function create(data) {
    return api.post(endpoints.create, data);
}