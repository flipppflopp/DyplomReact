const initialState = {
    user: {
            username: '',
            token: ''
        }
  };
  
function userReducer(state = initialState, action) {
    switch (action.type) {
        case 'SET_CREDENTIALS':
            return {
                ...state,
                username: action.payload.username,
                token: action.payload.token
            };
      default:
        return state;
    }
  }

  export default userReducer;