import {createSlice} from '@reduxjs/toolkit';

const initialState = {
    token: '',
    userID: '',
    userEmail: '',
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
            state.userEmail = action.payload.userEmail;
            state.name = action.payload.name;
            state.role = action.payload.role;
        },
        clearUser: () => {
            return initialState
        }
    },
});

export const {setUser, clearUser} = userSlice.actions;
export default userSlice.reducer;