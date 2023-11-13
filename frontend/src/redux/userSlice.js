import {createSlice} from '@reduxjs/toolkit';

const initialState = {
    token: '',
    userID: '',
    name: '',
    role: ''
};

const userSlice = createSlice({
    name: 'userSlice',
    initialState,
    reducers: {
        setUser: (state, action) => {
            state.token = action.payload.token;
            state.userID = action.payload.userID;
            state.name = action.payload.name;
            state.role = action.payload.role;
        },
        clearUser: (state) => {
            state.token = null;
            state.userID = null;
            state.name = null;
            state.role = null;
        }
    },
});

export const {setUser, clearUser} = userSlice.actions;
export default userSlice.reducer;