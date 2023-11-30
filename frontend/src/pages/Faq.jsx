import React, { useEffect, useState } from 'react';
import Cookies from 'js-cookie';
import '../App.css';

export default function Faq({authenticated}) {

  const [data, setData] = useState(null);
  const [isAdmin, setIsAdmin] = useState(false);
  const [qna, setQna] = useState({
    question: '',
    answer: '',
  });

  useEffect(() => {
    fetchData();
    checkAdmin();
  }, [authenticated]);

  const checkAdmin = () => {
    const loggedInRole = Cookies.get("role");
    if (loggedInRole == "Admin") {
      setIsAdmin(true);
    } else {
      setIsAdmin(false);
    }
  }

  const fetchData = async () => {
    try 
    {
      const response = await fetch(`http://localhost:5227/Qna/getall`);
      
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      
      const data = await response.json();
      setData(data);
    } catch (error) {
      console.error(error);
    }
  }

  const addQna = async () =>{
    try 
    {
      const response = await fetch(`http://localhost:5227/Qna/add`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${getTokenFromCookie()}`
        },
        body: JSON.stringify(qna),
      });
    
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      fetchData();
    } catch (error) {
      console.error(error);
    }
  }

  function getTokenFromCookie()
  {
    return Cookies.get("token");
  }

  const handleSubmit = (e) => {
    e.preventDefault();
    addQna();
    setQna({
      question: '',
      answer: '',
    });
  };  

  const handleChange = (e) => {
    const { name, value } = e.target;
    setQna({
      ...qna,
      [name]: value,
    });
  };

  return (
    <div className="faq-container">
      {data ? (
        <table className="faq-table">
          <thead>
            <tr>
              <th>Question</th>
              <th>Answer</th>
            </tr>
          </thead>
          <tbody>
            {data.map((qna) => (
              <tr key={qna.id}>
                <td>{qna.question}</td>
                <td>{qna.answer}</td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        'Loading...'
      )}
      {isAdmin && (
        <form className="faq-form" onSubmit={handleSubmit}>
          <div>
            <label htmlFor="question">Question:</label>
            <input
              type="text"
              id="question"
              name="question"
              value={qna.question}
              onChange={handleChange}
              required
            />
          </div>
          <div>
            <label htmlFor="answer">Answer:</label>
            <input
              type="text"
              id="answer"
              name="answer"
              value={qna.answer}
              onChange={handleChange}
              required
            />
          </div>
          <button type="submit">Add</button>
        </form>
      )}
    </div>
  );
}
