import * as api from './../api.js'

const endpoints = {
    all: '/data/pets?sortBy=_createdOn%20desc&distinct=name',
    create: '/data/pets',
    byId: '/data/pets/',
}

export async function getAll() {
    return api.get(endpoints.all);
}

export async function getById(id) {
    return api.get(endpoints.byId + id);
}

export async function create(data) {
    return api.post(endpoints.create, data);
}

export async function update(id, data) {
    return api.put(endpoints.byId + id, data);
}

export async function deleteById(id) {
    return api.del(endpoints.byId + id);
}