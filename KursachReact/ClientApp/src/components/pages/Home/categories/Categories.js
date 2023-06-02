import React, { useEffect, useState } from 'react';
import "./Categories.css"
import { connect } from 'react-redux'

function Categories(props){
  const [categories, setCategoriesState] = useState([]);
  const [isChecked, setIsChecked] = useState([]);

  useEffect(() => {
    fetchCategories();
  }, []);

  const SetCategories = () => {
    let reducerCategories = []

    categories.map((category, index) => {
      if(isChecked[index] === true){
        reducerCategories.push(categories[index])
      }
    })

    props.CategoriesToReducer(reducerCategories)
  }

  const fetchCategories = () => {
    fetch('/api/categories') 
    .then(response => response.json())
    .then(data => {
      setCategoriesState(data);

      data.map(() =>
      {
        let newFlags = isChecked
        newFlags.push(false)
        setIsChecked(newFlags)
      })
    })
    .catch(error => {
      console.log(error);
    });
  };

  
  const handleCheckboxChange = (event) => {
    var newChecks = isChecked
    newChecks[event.target.getAttribute('index')] = !newChecks[event.target.getAttribute('index')]; 
    
    setIsChecked(newChecks);
    
    SetCategories()
  };





  return (
    <div className='categories'>
      {categories.map((category, index) => {
        return(
          <div>
            <div>
              <input
              type="checkbox"
              index={index}
              checked={isChecked[index]}
              name={category.name}
              onChange={handleCheckboxChange}/>
            </div>

            <div>
              <p>{category.name}</p>
            </div>
        </div>
        )})}
    </div>
  );
};

const mapStateToProps = (state) => {
  return {
    categories: state.categories
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    CategoriesToReducer: (categories) => dispatch({ type: 'SET_CATEGORIES', payload: categories }),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Categories);