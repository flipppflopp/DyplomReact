const initialState = {
    categories: []
  };
  
function categoriesReducer(state = initialState, action) {
    switch (action.type) {
        case 'SET_CATEGORIES':
          let categories = []
          action.payload.map((category) => {
            categories.push(category.name)
          })
            return {
                ...state,
                categories: categories
            };
      default:
        return state;
    }
  }

  export default categoriesReducer;